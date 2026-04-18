using DepoNet.Business.DTOs;
using DepoNet.Business.Interfaces;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;

namespace DepoNet.Business.Services
{
    public class SiparisService : ISiparisService
    {
        private readonly ISiparisRepository _siparisRepository;
        private readonly IBOMService _bomService;
        private readonly IStokRepository _stokRepository;

        public SiparisService(
            ISiparisRepository siparisRepository,
            IBOMService bomService,
            IStokRepository stokRepository)
        {
            _siparisRepository = siparisRepository;
            _bomService = bomService;
            _stokRepository = stokRepository;
        }

        public async Task<List<Siparis>> GetAllAsync()
        {
            return await _siparisRepository.GetAllAsync();
        }

        public async Task<Siparis?> GetByIdAsync(int id)
        {
            return await _siparisRepository.GetByIdWithDetaylarAsync(id);
        }

        public async Task AddAsync(Siparis siparis)
        {
            await _siparisRepository.AddAsync(siparis);
        }

        public async Task UpdateAsync(Siparis siparis)
        {
            await _siparisRepository.UpdateAsync(siparis);
        }

        public async Task DeleteAsync(int id)
        {
            await _siparisRepository.DeleteAsync(id);
        }

        public async Task<List<IhtiyacSonuc>> IhtiyacAnaliziAsync(int siparisId)
        {
            // Siparişi detaylarıyla getir
            var siparis = await _siparisRepository.GetByIdWithDetaylarAsync(siparisId);
            if (siparis == null)
                throw new Exception("Sipariş bulunamadı.");

            // BOM'u patlat — tüm parça ihtiyaçlarını hesapla
            var ihtiyacMap = await _bomService.BOMPatlat(siparis.Detaylar.ToList());

            // Her parça için stokla karşılaştır
            var sonuclar = new List<IhtiyacSonuc>();

            foreach (var (urunId, ihtiyacMiktar) in ihtiyacMap)
            {
                // Tüm depolardaki toplam stoku hesapla
                var stoklar = await _stokRepository.GetAllAsync();
                var mevcutMiktar = stoklar
                    .Where(s => s.UrunId == urunId)
                    .Sum(s => s.Miktar);

                var fark = mevcutMiktar - ihtiyacMiktar;

                sonuclar.Add(new IhtiyacSonuc
                {
                    UrunId = urunId,
                    UrunAd = stoklar.FirstOrDefault(s => s.UrunId == urunId)?.Urun?.Ad ?? "Bilinmiyor",
                    UrunKod = stoklar.FirstOrDefault(s => s.UrunId == urunId)?.Urun?.Kod ?? "-",
                    IhtiyacMiktar = ihtiyacMiktar,
                    MevcutMiktar = mevcutMiktar,
                    Fark = fark,
                    Durum = fark >= 0 ? (fark == 0 ? "Tamam" : "Fazla") : "Eksik"
                });
            }

            return sonuclar;
        }
    }
}
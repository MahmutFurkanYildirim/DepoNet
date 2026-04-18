using DepoNet.Business.Interfaces;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;

namespace DepoNet.Business.Services
{
    public class StokService : IStokService
    {
        private readonly IStokRepository _stokRepository;

        public StokService(IStokRepository stokRepository)
        {
            _stokRepository = stokRepository;
        }

        public async Task<List<Stok>> GetAllAsync()
        {
            return await _stokRepository.GetAllAsync();
        }

        public async Task StokGirisAsync(int urunId, int depoId, decimal miktar, string aciklama)
        {
            // Bu ürün bu depoda daha önce kayıt var mı?
            var stok = await _stokRepository.GetByUrunDepoAsync(urunId, depoId);

            if (stok == null)
            {
                // İlk defa giriş yapılıyor, yeni kayıt oluştur
                stok = new Stok
                {
                    UrunId = urunId,
                    DepoId = depoId,
                    Miktar = miktar
                };
                await _stokRepository.AddAsync(stok);
            }
            else
            {
                // Zaten var, üstüne ekle
                stok.Miktar += miktar;
                await _stokRepository.UpdateAsync(stok);
            }

            // Her iki durumda da hareketi kaydet
            await _stokRepository.AddHareketAsync(new StokHareket
            {
                StokId = stok.StokId,
                Tip = "Giris",
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = aciklama
            });
        }

        public async Task StokCikisAsync(int urunId, int depoId, decimal miktar, string aciklama)
        {
            var stok = await _stokRepository.GetByUrunDepoAsync(urunId, depoId);

            if (stok == null)
                throw new Exception("Bu ürün için stok kaydı bulunamadı.");

            if (stok.Miktar < miktar)
                throw new Exception($"Yetersiz stok. Mevcut: {stok.Miktar}, İstenen: {miktar}");

            stok.Miktar -= miktar;
            await _stokRepository.UpdateAsync(stok);

            await _stokRepository.AddHareketAsync(new StokHareket
            {
                StokId = stok.StokId,
                Tip = "Cikis",
                Miktar = miktar,
                Tarih = DateTime.Now,
                Aciklama = aciklama
            });
        }
    }
}
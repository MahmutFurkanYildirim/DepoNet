using DepoNet.Business.Interfaces;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;

namespace DepoNet.Business.Services
{
    public class UrunService : IUrunService
    {
        private readonly IUrunRepository _urunRepository;

        public UrunService(IUrunRepository urunRepository)
        {
            _urunRepository = urunRepository;
        }

        public async Task<List<Urun>> GetAllAsync()
        {
            return await _urunRepository.GetAllAsync();
        }

        public async Task<Urun?> GetByIdAsync(int id)
        {
            return await _urunRepository.GetByIdAsync(id);
        }

        public async Task AddAsync(Urun urun)
        {
            // Aynı kodda ürün var mı kontrol et
            var tumUrunler = await _urunRepository.GetAllAsync();
            if (tumUrunler.Any(u => u.Kod == urun.Kod))
                throw new Exception($"'{urun.Kod}' kodlu ürün zaten mevcut.");

            await _urunRepository.AddAsync(urun);
        }

        public async Task UpdateAsync(Urun urun)
        {
            await _urunRepository.UpdateAsync(urun);
        }

        public async Task DeleteAsync(int id)
        {
            await _urunRepository.DeleteAsync(id);
        }
    }
}
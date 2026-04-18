using DepoNet.Data.Entities;

namespace DepoNet.Business.Interfaces
{
    public interface IBOMService
    {
        Task<List<BOM>> GetByUstUrunIdAsync(int ustUrunId);
        Task AddAsync(BOM bom);
        Task DeleteAsync(int bomId);

        // En kritik metod — siparişe göre tüm parça ihtiyacını hesaplar
        Task<Dictionary<int, decimal>> BOMPatlat(List<SiparisDetay> siparisDetaylar);
    }
}
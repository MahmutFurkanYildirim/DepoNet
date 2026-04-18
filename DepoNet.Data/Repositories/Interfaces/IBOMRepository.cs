using DepoNet.Data.Entities;

namespace DepoNet.Data.Repositories.Interfaces
{
    public interface IBOMRepository
    {
        Task<List<BOM>> GetAllAsync();
        Task<List<BOM>> GetByUstUrunIdAsync(int ustUrunId);
        Task AddAsync(BOM bom);
        Task DeleteAsync(int bomId);
    }
}
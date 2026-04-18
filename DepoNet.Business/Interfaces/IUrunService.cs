using DepoNet.Data.Entities;

namespace DepoNet.Business.Interfaces
{
    public interface IUrunService
    {
        Task<List<Urun>> GetAllAsync();
        Task<Urun?> GetByIdAsync(int id);
        Task AddAsync(Urun urun);
        Task UpdateAsync(Urun urun);
        Task DeleteAsync(int id);
    }
}
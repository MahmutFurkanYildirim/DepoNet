using DepoNet.Data.Entities;

namespace DepoNet.Data.Repositories.Interfaces
{
    public interface IUrunRepository
    {
        Task<List<Urun>> GetAllAsync();
        Task<Urun?> GetByIdAsync(int id);
        Task AddAsync(Urun urun);
        Task UpdateAsync(Urun urun);
        Task DeleteAsync(int id);
    }
}
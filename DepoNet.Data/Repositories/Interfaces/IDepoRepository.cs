using DepoNet.Data.Entities;

namespace DepoNet.Data.Repositories.Interfaces
{
    public interface IDepoRepository
    {
        Task<List<Depo>> GetAllAsync();
        Task<Depo?> GetByIdAsync(int id);
        Task AddAsync(Depo depo);
        Task UpdateAsync(Depo depo);
        Task DeleteAsync(int id);
    }
}
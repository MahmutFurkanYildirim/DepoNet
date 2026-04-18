using DepoNet.Data.Entities;

namespace DepoNet.Business.Interfaces
{
    public interface IDepoService
    {
        Task<List<Depo>> GetAllAsync();
        Task AddAsync(Depo depo);
        Task UpdateAsync(Depo depo);
        Task DeleteAsync(int id);
    }
}
using DepoNet.Data.Entities;

namespace DepoNet.Data.Repositories.Interfaces
{
    public interface ISiparisRepository
    {
        Task<List<Siparis>> GetAllAsync();
        Task<Siparis?> GetByIdWithDetaylarAsync(int id);
        Task AddAsync(Siparis siparis);
        Task UpdateAsync(Siparis siparis);
        Task DeleteAsync(int id);
    }
}
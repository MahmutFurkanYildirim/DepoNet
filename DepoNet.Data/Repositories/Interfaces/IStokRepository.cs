using DepoNet.Data.Entities;

namespace DepoNet.Data.Repositories.Interfaces
{
    public interface IStokRepository
    {
        Task<List<Stok>> GetAllAsync();
        Task<Stok?> GetByUrunDepoAsync(int urunId, int depoId);
        Task AddAsync(Stok stok);
        Task UpdateAsync(Stok stok);
        Task AddHareketAsync(StokHareket hareket);
    }
}
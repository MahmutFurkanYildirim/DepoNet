using DepoNet.Data.Entities;

namespace DepoNet.Business.Interfaces
{
    public interface IStokService
    {
        Task<List<Stok>> GetAllAsync();
        Task StokGirisAsync(int urunId, int depoId, decimal miktar, string aciklama);
        Task StokCikisAsync(int urunId, int depoId, decimal miktar, string aciklama);
    }
}
using DepoNet.Business.DTOs;
using DepoNet.Data.Entities;

namespace DepoNet.Business.Interfaces
{
    public interface ISiparisService
    {
        Task<List<Siparis>> GetAllAsync();
        Task<Siparis?> GetByIdAsync(int id);
        Task AddAsync(Siparis siparis);
        Task UpdateAsync(Siparis siparis);
        Task DeleteAsync(int id);

        // Siparişi analiz et — eksik/fazla/tamam listesi döner
        Task<List<IhtiyacSonuc>> IhtiyacAnaliziAsync(int siparisId);
    }
}
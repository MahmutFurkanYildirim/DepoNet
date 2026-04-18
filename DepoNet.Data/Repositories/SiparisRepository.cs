using DepoNet.Data.Context;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Repositories
{
    public class SiparisRepository : ISiparisRepository
    {
        private readonly AppDbContext _context;

        public SiparisRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Siparis>> GetAllAsync()
        {
            return await _context.Siparisler
                .Include(s => s.Detaylar)
                    .ThenInclude(d => d.Urun) // Detayların ürün bilgilerini de çek
                .ToListAsync();
        }

        public async Task<Siparis?> GetByIdWithDetaylarAsync(int id)
        {
            return await _context.Siparisler
                .Include(s => s.Detaylar)
                    .ThenInclude(d => d.Urun)
                .FirstOrDefaultAsync(s => s.SiparisId == id);
        }

        public async Task AddAsync(Siparis siparis)
        {
            await _context.Siparisler.AddAsync(siparis);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Siparis siparis)
        {
            _context.Siparisler.Update(siparis);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var siparis = await _context.Siparisler.FindAsync(id);
            if (siparis != null)
            {
                _context.Siparisler.Remove(siparis);
                await _context.SaveChangesAsync();
            }
        }
    }
}
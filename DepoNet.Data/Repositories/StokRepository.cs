using DepoNet.Data.Context;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Repositories
{
    public class StokRepository : IStokRepository
    {
        private readonly AppDbContext _context;

        public StokRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Stok>> GetAllAsync()
        {
            return await _context.Stoklar
                .Include(s => s.Urun)
                .Include(s => s.Depo)
                .ToListAsync();
        }

        public async Task<Stok?> GetByUrunDepoAsync(int urunId, int depoId)
        {
            // Belirli bir ürünün belirli bir depodaki stok kaydı
            return await _context.Stoklar
                .FirstOrDefaultAsync(s => s.UrunId == urunId && s.DepoId == depoId);
        }

        public async Task AddAsync(Stok stok)
        {
            await _context.Stoklar.AddAsync(stok);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Stok stok)
        {
            _context.Stoklar.Update(stok);
            await _context.SaveChangesAsync();
        }

        public async Task AddHareketAsync(StokHareket hareket)
        {
            await _context.StokHareketler.AddAsync(hareket);
            await _context.SaveChangesAsync();
        }
    }
}
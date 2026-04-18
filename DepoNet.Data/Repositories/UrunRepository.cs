using DepoNet.Data.Context;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Repositories
{
    public class UrunRepository : IUrunRepository
    {
        private readonly AppDbContext _context;

        // DI ile AppDbContext buraya enjekte edilecek
        public UrunRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Urun>> GetAllAsync()
        {
            // AktifMi = true olanları getir, silinmişleri getirme
            return await _context.Urunler
                .Where(u => u.AktifMi)
                .ToListAsync();
        }

        public async Task<Urun?> GetByIdAsync(int id)
        {
            return await _context.Urunler.FindAsync(id);
        }

        public async Task AddAsync(Urun urun)
        {
            await _context.Urunler.AddAsync(urun);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Urun urun)
        {
            _context.Urunler.Update(urun);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var urun = await GetByIdAsync(id);
            if (urun != null)
            {
                // Hard delete değil soft delete — AktifMi = false yapıyoruz
                // Yani DB'den silmiyoruz, sadece gizliyoruz
                urun.AktifMi = false;
                await UpdateAsync(urun);
            }
        }
    }
}
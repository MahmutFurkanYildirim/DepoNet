using DepoNet.Data.Context;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Repositories
{
    public class BOMRepository : IBOMRepository
    {
        private readonly AppDbContext _context;

        public BOMRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<BOM>> GetAllAsync()
        {
            // Include ile ilişkili ürün bilgilerini de çek
            return await _context.BOMs
                .Include(b => b.UstUrun)
                .Include(b => b.AltUrun)
                .ToListAsync();
        }

        public async Task<List<BOM>> GetByUstUrunIdAsync(int ustUrunId)
        {
            // X silahının tüm parçalarını getir
            return await _context.BOMs
                .Include(b => b.AltUrun)
                .Where(b => b.UstUrunId == ustUrunId)
                .ToListAsync();
        }

        public async Task AddAsync(BOM bom)
        {
            await _context.BOMs.AddAsync(bom);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int bomId)
        {
            var bom = await _context.BOMs.FindAsync(bomId);
            if (bom != null)
            {
                _context.BOMs.Remove(bom);
                await _context.SaveChangesAsync();
            }
        }
    }
}
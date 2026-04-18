using DepoNet.Data.Context;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DepoNet.Data.Repositories
{
    public class DepoRepository : IDepoRepository
    {
        private readonly AppDbContext _context;

        public DepoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Depo>> GetAllAsync()
        {
            return await _context.Depolar
                .Where(d => d.AktifMi)
                .ToListAsync();
        }

        public async Task<Depo?> GetByIdAsync(int id)
        {
            return await _context.Depolar.FindAsync(id);
        }

        public async Task AddAsync(Depo depo)
        {
            await _context.Depolar.AddAsync(depo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Depo depo)
        {
            _context.Depolar.Update(depo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var depo = await GetByIdAsync(id);
            if (depo != null)
            {
                depo.AktifMi = false;
                await UpdateAsync(depo);
            }
        }
    }
}
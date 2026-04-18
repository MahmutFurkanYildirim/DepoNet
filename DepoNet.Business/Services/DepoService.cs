using DepoNet.Business.Interfaces;
using DepoNet.Data.Entities;
using DepoNet.Data.Repositories.Interfaces;

namespace DepoNet.Business.Services
{
    public class DepoService : IDepoService
    {
        private readonly IDepoRepository _depoRepository;

        public DepoService(IDepoRepository depoRepository)
        {
            _depoRepository = depoRepository;
        }

        public async Task<List<Depo>> GetAllAsync()
        {
            return await _depoRepository.GetAllAsync();
        }

        public async Task AddAsync(Depo depo)
        {
            await _depoRepository.AddAsync(depo);
        }

        public async Task UpdateAsync(Depo depo)
        {
            await _depoRepository.UpdateAsync(depo);
        }

        public async Task DeleteAsync(int id)
        {
            await _depoRepository.DeleteAsync(id);
        }
    }
}
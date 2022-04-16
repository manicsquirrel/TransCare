using Microsoft.EntityFrameworkCore;
using TransCare.Interfaces;
using TransCare.Models;

namespace TransCare.Data.Repositories
{
    public class HealthProviderRepository : IHealthProviderRepository
    {
        private readonly TransCareContextDb _transCareContext;

        public HealthProviderRepository(TransCareContextDb transCareContext)
        {
            _transCareContext = transCareContext;
        }

        public async Task DeleteAsync(int id)
        {
            var provider = await _transCareContext.HealthProviders.SingleAsync(p => p.Id == id);
            _transCareContext.HealthProviders.Remove(provider);
            await _transCareContext.SaveChangesAsync();
        }

        public async Task<HealthProvider> GetAsync(int id) =>
             await _transCareContext.HealthProviders.SingleAsync(p => p.Id == id);

        public async Task<IEnumerable<HealthProvider>> GetAllAsync() =>
            await _transCareContext.HealthProviders.ToListAsync();

        public async Task<IEnumerable<HealthProvider>> GetFilteredAsync(string query) => await _transCareContext.HealthProviders
                .Where(p => p.ProviderName.Contains(query)
                    || p.Notes.Contains(query)
                    || p.Phone.Contains(query)
                    || p.State.Code.Contains(query)
                    || p.State.Name.Contains(query)
                    || p.City.Contains(query)
                    || p.Street.Contains(query))
                .ToListAsync();

        public async Task<HealthProvider> SaveAsync(HealthProvider provider)
        {
            var entity = await _transCareContext.HealthProviders.SingleAsync(p => p.Id == provider.Id);
            if (entity == null)
            {
                var entry = await _transCareContext.AddAsync(provider);
                entity = entry.Entity;
            }
            else
            {
                _transCareContext.Entry(entity).CurrentValues.SetValues(provider);
            }
            _transCareContext.SaveChanges();
            return entity;
        }
    }
}
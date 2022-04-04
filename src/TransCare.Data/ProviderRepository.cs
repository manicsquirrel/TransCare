using TransCare.Entities;
using TransCare.Interfaces;

namespace TransCare.Data
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly TransCareContext _transCareContext;

        public ProviderRepository(TransCareContext transCareContext)
        {
            _transCareContext = transCareContext;
        }

        public void Delete(int id)
        {
            var provider = _transCareContext.HealthProviders.Single(p => p.Id == id);
            _transCareContext.HealthProviders.Remove(provider);
            _transCareContext.SaveChanges();
        }

        public HealthProvider Get(int id) => _transCareContext.HealthProviders.Single(p => p.Id == id);

        public IEnumerable<HealthProvider> GetAll() => _transCareContext.HealthProviders.ToList();

        public IEnumerable<HealthProvider> GetFiltered(string query)
        {
            IQueryable<HealthProvider> queryableObject = _transCareContext.HealthProviders;
            queryableObject = queryableObject.Where(p =>
                 p.ProviderName.Contains(query)
                 || p.Notes.Contains(query)
                 || p.Phone.Contains(query)
                 || p.State.Contains(query)
                 || p.Street.Contains(query));

            return queryableObject.OrderBy(p => p.ProviderName);
        }

        public HealthProvider Save(HealthProvider provider)
        {
            var entity = _transCareContext.HealthProviders.FirstOrDefault(p => p.Id == provider.Id);
            if (entity == null)
            {
                var entry = _transCareContext.Add(provider);
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
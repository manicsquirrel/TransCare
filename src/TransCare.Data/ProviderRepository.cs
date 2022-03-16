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
            var provider = _transCareContext.Providers.Single(p => p.Id == id);
            _transCareContext.Providers.Remove(provider);
            _transCareContext.SaveChanges();
        }

        public Provider Get(int id) => _transCareContext.Providers.Single(p => p.Id == id);

        public IEnumerable<Provider> GetAll() => _transCareContext.Providers.ToList();

        public IEnumerable<Provider> GetFiltered(string query)
        {
            IQueryable<Provider> queryableObject = _transCareContext.Providers;

            queryableObject = queryableObject.Where(p =>
                 p.ProviderName.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Notes.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Phone.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.State.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Street.Contains(query, StringComparison.CurrentCultureIgnoreCase));

            return queryableObject.OrderBy(p => p.ProviderName);
        }

        public Provider Save(Provider provider)
        {
            var entity = _transCareContext.Providers.Single(p => p.Id == provider.Id);
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
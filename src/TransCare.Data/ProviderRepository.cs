using TransCare.Interfaces;

namespace TransCare.Data
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly ProviderContext _providerContext;

        public ProviderRepository(ProviderContext providerContext)
        {
            _providerContext = providerContext;
        }

        public void Delete(int id)
        {
            var provider = _providerContext.Providers.Single(p => p.Id == id);
            _providerContext.Providers.Remove(provider);
            _providerContext.SaveChanges();
        }

        public Provider Get(int id) => _providerContext.Providers.Single(p => p.Id == id);

        public IEnumerable<Provider> GetAll() => _providerContext.Providers.ToList();

        public IEnumerable<Provider> GetFiltered(string query)
        {
            IQueryable<Provider> queryableObject = _providerContext.Providers;

            queryableObject = queryableObject.Where(p =>
                 p.Name.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Notes.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Phone.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.State.Contains(query, StringComparison.CurrentCultureIgnoreCase)
                 || p.Street.Contains(query, StringComparison.CurrentCultureIgnoreCase));

            return queryableObject.OrderBy(p => p.Name);
        }

        public Provider Save(Provider provider)
        {
            var entity = _providerContext.Providers.Single(p => p.Id == provider.Id);
            if (entity == null)
            {
                var entry = _providerContext.Add(provider);
                entity = entry.Entity;
            }
            else
            {
                _providerContext.Entry(entity).CurrentValues.SetValues(provider);
            }
            _providerContext.SaveChanges();
            return entity;
        }
    }
}
using TransCare.Data.Entities;
using TransCare.Interfaces;
using TransCare.Models;

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

        public HealthProvider Get(int id) =>
            Map(_transCareContext.HealthProviders.Single(p => p.Id == id), _transCareContext.States);

        public IEnumerable<HealthProvider> GetAll() =>
            Map(_transCareContext.HealthProviders, _transCareContext.States);

        public IEnumerable<HealthProvider> GetFiltered(string query)
        {
            var providers=Map(_transCareContext.HealthProviders, _transCareContext.States)
                .Where(p => p.ProviderName.Contains(query)
                    || p.Notes.Contains(query)
                    || p.Phone.Contains(query)
                    || p.State.Code.Contains(query)
                    || p.State.Name.Contains(query)
                    || p.City.Contains(query)
                    || p.Street.Contains(query));
            return providers;
        }

        public HealthProvider Save(HealthProvider provider)
        {            
            var entity = _transCareContext.HealthProviders.FirstOrDefault(p => p.Id == provider.Id);
            if (entity == null)
            {
                var entry = _transCareContext.Add(Map(provider));
                entity = entry.Entity;
            }
            else
            {
                _transCareContext.Entry(entity).CurrentValues.SetValues(Map(provider));
            }
            _transCareContext.SaveChanges();
            return Map(entity, _transCareContext.States);
        }

        private static IQueryable<HealthProvider> Map(IQueryable<HealthProviderData> providers, IQueryable<StateData> states) =>
            from p in providers
            join s in states
            on p.State equals s.Code into data
            from state in data.DefaultIfEmpty()
            select new HealthProvider
            {
                Id = p.Id,
                Email = p.Email,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                ProviderName = p.ProviderName,
                Notes = p.Notes,
                Phone = p.Phone,
                Url = p.Url,
                City = p.City,
                State = new State { Code = p.State, Name = state.Name },
                Street = p.Street,
                ZipCode = p.ZipCode
            };

        private static HealthProviderData Map(HealthProvider provider) =>
            new()
            {
                Id = provider.Id,
                Email = provider.Email,
                Latitude = provider.Latitude,
                Longitude = provider.Longitude,
                ProviderName = provider.ProviderName,
                Notes = provider.Notes,
                Phone = provider.Phone,
                Url = provider.Url,
                City = provider.City,
                State = provider.State.Code,
                Street = provider.Street,
                ZipCode = provider.ZipCode
            };

        private static HealthProvider Map(HealthProviderData provider, IQueryable<StateData> states)
        {
            return new()
            {
                Id = provider.Id,
                Email = provider.Email,
                Latitude = provider.Latitude,
                Longitude = provider.Longitude,
                ProviderName = provider.ProviderName,
                Notes = provider.Notes,
                Phone = provider.Phone,
                Url = provider.Url,
                City = provider.City,
                State = new State
                {
                    Code = provider.State,
                    Name = states.ToList().Where(s => string.Compare(s.Code, provider.State, true) == 0)
                        .FirstOrDefault()
                        ?.Name
                        ?? ""
                },
                Street = provider.Street,
                ZipCode = provider.ZipCode
            };
        }
    }
}
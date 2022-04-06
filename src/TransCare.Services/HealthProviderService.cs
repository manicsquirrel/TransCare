using TransCare.Models;
using TransCare.Interfaces;
using TransCare.Services.Abstractions;

namespace TransCare.Services
{
    public class HealthProviderService : IHealthProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public HealthProviderService(IProviderRepository providerRepository) => _providerRepository = providerRepository;

        public void Delete(int id) => _providerRepository.Delete(id);

        public HealthProvider Get(int id) => _providerRepository.Get(id);

        public IEnumerable<HealthProvider> GetAll() => _providerRepository.GetAll();

        public IEnumerable<HealthProvider> GetFiltered(string query) => _providerRepository.GetFiltered(query);

        public HealthProvider Save(HealthProvider provider) => _providerRepository.Save(provider);
    }
}
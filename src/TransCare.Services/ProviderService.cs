using TransCare.Interfaces;
using TransCare.Services.Abstractions;

namespace TransCare.Services
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository _providerRepository;

        public ProviderService(IProviderRepository providerRepository) => _providerRepository = providerRepository;

        public void Delete(int id) => _providerRepository.Delete(id);

        public Provider Get(int id) => _providerRepository.Get(id);

        public IEnumerable<Provider> GetAll() => _providerRepository.GetAll();

        public IEnumerable<Provider> GetFiltered(string query) => _providerRepository.GetFiltered(query);

        public Provider Save(Provider provider) => _providerRepository.Save(provider);
    }
}
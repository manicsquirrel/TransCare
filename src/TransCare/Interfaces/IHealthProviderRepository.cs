using TransCare.Models;

namespace TransCare.Interfaces
{
    public interface IHealthProviderRepository
    {
        Task<HealthProvider> GetAsync(int id);

        Task<IEnumerable<HealthProvider>> GetAllAsync();

        Task<HealthProvider> SaveAsync(HealthProvider provider);

        Task DeleteAsync(int id);

        Task<IEnumerable<HealthProvider>> GetFilteredAsync(string query);
    }
}
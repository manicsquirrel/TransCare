using TransCare.Models;

namespace TransCare.Services.Abstractions
{
    public interface IHealthProviderService
    {
        Task DeleteAsync(int id);

        Task<IEnumerable<HealthProvider>> GetAllAsync();

        Task<HealthProvider> GetAsync(int id);

        Task<IEnumerable<HealthProvider>> GetFilteredAsync(string query);

        Task<IEnumerable<HealthProvider>> GetNearestAsync(int take, double latitude, double longitude);

        Task<HealthProvider> SaveAsync(HealthProvider provider);
    }
}
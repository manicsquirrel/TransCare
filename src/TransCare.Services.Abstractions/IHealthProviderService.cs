using TransCare.Entities;

namespace TransCare.Services.Abstractions
{
    public interface IHealthProviderService
    {
        HealthProvider Get(int id);

        IEnumerable<HealthProvider> GetAll();

        HealthProvider Save(HealthProvider provider);

        void Delete(int id);

        IEnumerable<HealthProvider> GetFiltered(string query);
    }
}
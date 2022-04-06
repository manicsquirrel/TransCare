using TransCare.Models;

namespace TransCare.Interfaces
{
    public interface IProviderRepository
    {
        HealthProvider Get(int id);

        IEnumerable<HealthProvider> GetAll();

        HealthProvider Save(HealthProvider provider);

        void Delete(int id);

        IEnumerable<HealthProvider> GetFiltered(string query);
    }
}
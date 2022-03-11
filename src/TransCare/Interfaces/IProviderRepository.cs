namespace TransCare.Interfaces
{
    public interface IProviderRepository
    {
        Provider Get(int id);

        IEnumerable<Provider> GetAll();

        Provider Save(Provider provider);

        void Delete(int id);

        IEnumerable<Provider> GetFiltered(string query);
    }
}
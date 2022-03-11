namespace TransCare.Services.Abstractions
{
    public interface IProviderService
    {
        Provider Get(int id);

        IEnumerable<Provider> GetAll();

        Provider Save(Provider provider);

        void Delete(int id);

        IEnumerable<Provider> GetFiltered(string query);
    }
}
using TransCare.Models;

namespace TransCare.Interfaces
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> GetAllAsync();
    }
}
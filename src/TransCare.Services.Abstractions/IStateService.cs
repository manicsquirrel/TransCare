using TransCare.Models;

namespace TransCare.Services.Abstractions
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetAllAsync();
    }
}
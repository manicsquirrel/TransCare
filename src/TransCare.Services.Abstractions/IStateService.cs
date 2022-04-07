using TransCare.Models;

namespace TransCare.Services.Abstractions
{
    public interface IStateService
    {
        IEnumerable<State> GetAll();
    }
}
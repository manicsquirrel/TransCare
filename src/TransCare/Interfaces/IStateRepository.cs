using TransCare.Entities;

namespace TransCare.Interfaces
{
    public interface IStateRepository
    {
        State Get(string code);

        IEnumerable<State> GetAll();
    }
}
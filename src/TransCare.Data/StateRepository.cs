using TransCare.Entities;
using TransCare.Interfaces;

namespace TransCare.Data
{
    public class StateRepository : IStateRepository
    {
        private readonly TransCareContext _transCareContext;

        public StateRepository(TransCareContext transCareContext)
        {
            _transCareContext = transCareContext;
        }

        public State Get(string code) => _transCareContext.States.Single(s => s.Code == code);

        public IEnumerable<State> GetAll() => _transCareContext.States.ToList();
    }
}
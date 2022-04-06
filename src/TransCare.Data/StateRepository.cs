using TransCare.Data.Entities;
using TransCare.Interfaces;
using TransCare.Models;

namespace TransCare.Data
{
    public class StateRepository : IStateRepository
    {
        private readonly TransCareContext _transCareContext;

        public StateRepository(TransCareContext transCareContext)
        {
            _transCareContext = transCareContext;
        }

        public State Get(string code) =>
            Map(_transCareContext.States.Single(s => s.Code == code));

        public IEnumerable<State> GetAll() =>
            Map(_transCareContext.States).OrderBy(s=>s.Name);

        private IEnumerable<State> Map(IQueryable<StateData> stateData)
        {
            var states = new List<State>();
            stateData.ToList().ForEach(s => states.Add(Map(s)));
            return states;
        }

        private static State Map(StateData stateData) =>
            new()
            {
                Code = stateData.Code,
                Name = stateData.Name,
            };
    }
}
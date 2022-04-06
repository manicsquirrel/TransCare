using TransCare.Interfaces;
using TransCare.Models;
using TransCare.Services.Abstractions;

namespace TransCare.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository) => _stateRepository = stateRepository;

        public IEnumerable<State> GetAll() => _stateRepository.GetAll();
    }
}
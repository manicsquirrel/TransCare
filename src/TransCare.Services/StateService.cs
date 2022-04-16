using TransCare.Interfaces;
using TransCare.Models;
using TransCare.Services.Abstractions;

namespace TransCare.Services
{
    public class StateService : IStateService
    {
        private readonly IStateRepository _stateRepository;

        public StateService(IStateRepository stateRepository) =>
            _stateRepository = stateRepository;

        public async Task<IEnumerable<State>> GetAllAsync() =>
            await _stateRepository.GetAllAsync();
    }
}
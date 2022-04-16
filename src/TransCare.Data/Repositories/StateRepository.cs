using Microsoft.EntityFrameworkCore;
using TransCare.Interfaces;
using TransCare.Models;

namespace TransCare.Data.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly TransCareContextDb _transCareContext;

        public StateRepository(TransCareContextDb transCareContext)
        {
            _transCareContext = transCareContext;
        }

        public async Task<IEnumerable<State>> GetAllAsync() =>
            await _transCareContext.States.OrderBy(s => s.Name).ToListAsync();
    }
}
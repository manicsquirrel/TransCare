using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TransCare.Models;
using TransCare.Services.Abstractions;

namespace TransCare.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StateController : Controller
    {
        private readonly IStateService _stateService;
        private readonly IMapper _mapper;

        public StateController(IStateService StateService, IMapper mapper)
        {
            _stateService = StateService;
            _mapper = mapper;
        }

        [HttpGet("list")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<StateResponse>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<State>, IEnumerable<StateResponse>>(await _stateService.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
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
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<State>, IEnumerable<StateResponse>>(_stateService.GetAll()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
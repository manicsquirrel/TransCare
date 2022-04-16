using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using TransCare.Models;
using TransCare.Services.Abstractions;
using TransCare.Web.Models.Responses;

namespace TransCare.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthProviderController : Controller
    {
        private readonly IHealthProviderService _healthProviderService;
        private readonly IMapper _mapper;

        public HealthProviderController(IHealthProviderService healthProviderService, IMapper mapper)
        {
            _healthProviderService = healthProviderService;
            _mapper = mapper;
        }

        [HttpGet("search")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProviderResponse>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> SearchAsync(string query)
        {
            if (string.IsNullOrWhiteSpace(query)) return Ok(new List<HealthProviderResponse>());

            try
            {
                return Ok(_mapper.Map<IEnumerable<HealthProvider>, IEnumerable<HealthProviderResponse>>
                    (await _healthProviderService.GetFilteredAsync(query)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("nearme")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProviderResponse>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetNearestAsync([FromQuery] HealthProviderNearMeRequest healthProviderNearMeRequest)
        {
            if (healthProviderNearMeRequest==null) return Ok(new List<HealthProviderResponse>());

            try
            {
                return Ok(_mapper.Map<IEnumerable<HealthProvider>, IEnumerable<HealthProviderResponse>>
                    (await _healthProviderService.GetNearestAsync(
                        healthProviderNearMeRequest.Take, 
                        healthProviderNearMeRequest.Latitude, 
                        healthProviderNearMeRequest.Longitude)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("list")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProviderResponse>))]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<HealthProvider>, IEnumerable<HealthProviderResponse>>
                    (await _healthProviderService.GetAllAsync()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProviderResponse>))]
        [SwaggerResponse(404, "Health provider not found.")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> GetAsync(int id)
        {
            try
            {
                return Ok(_mapper.Map<HealthProvider, HealthProviderResponse>
                    (await _healthProviderService.GetAsync(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("save")]
        [Produces("application/json")]
        [SwaggerResponse(201, "Inserts or updates a health provider", typeof(HealthProviderResponse))]
        [SwaggerResponse(400, "Bad request. Invalid parameter.")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> CreateAsync([FromBody] HealthProviderRequest request)
        {
            if (request == null) return BadRequest("Invalid save request. Request body null or empty");
            try
            {
                var provider = _mapper.Map<HealthProviderRequest, HealthProvider>(request);
                return Ok(_mapper.Map<HealthProvider, HealthProviderResponse>(await _healthProviderService.SaveAsync(provider)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpDelete("delete")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Deletes a health provider by id.")]
        [SwaggerResponse(400, "Bad request. Invalid parameter.")]
        [SwaggerResponse(500, "Internal server error")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            if (id == 0) return BadRequest("Invalid save request. Request body null or empty");
            try
            {
                await _healthProviderService.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
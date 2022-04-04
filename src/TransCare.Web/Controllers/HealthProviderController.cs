using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using TransCare.Models;
using TransCare.Services.Abstractions;
using TransCare.Web.Pages;
using AutoMapper;
using TransCare.Web.Models.Responses;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProvider>))]
        [SwaggerResponse(500, "Internal server error")]
        public IActionResult Search(string query)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<HealthProvider>, IEnumerable<HealthProviderResponse>>(_healthProviderService.GetFiltered(query)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet("list")]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProvider>))]
        [SwaggerResponse(500, "Internal server error")]
        public IActionResult Get()
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<HealthProvider>, IEnumerable<HealthProviderResponse>>(_healthProviderService.GetAll()));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        [SwaggerResponse(200, "Returns a collection of health providers", typeof(IEnumerable<HealthProvider>))]
        [SwaggerResponse(404, "Health provider not found.")]
        [SwaggerResponse(500, "Internal server error")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_mapper.Map<HealthProvider, HealthProviderResponse>(_healthProviderService.Get(id)));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }

        [HttpPost("save")]
        [Produces("application/json")]
        [SwaggerResponse(201, "Inserts or updates a health provider", typeof(HealthProvider))]
        [SwaggerResponse(400, "Bad request. Invalid parameter.")]
        [SwaggerResponse(500, "Internal server error")]
        public IActionResult Create([FromBody] HealthProvider request)
        {
            if (request == null) return BadRequest("Invalid save request. Request body null or empty");
            try
            {
                return Ok(_mapper.Map<HealthProvider, HealthProviderResponse>(_healthProviderService.Save(request)));
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
        public IActionResult Delete(int id)
        {
            if (id == 0) return BadRequest("Invalid save request. Request body null or empty");
            try
            {
                _healthProviderService.Delete(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.ToString());
            }
        }
    }
}
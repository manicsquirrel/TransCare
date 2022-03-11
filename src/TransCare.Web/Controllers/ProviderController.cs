using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TransCare.Services.Abstractions;

namespace TransCare.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProviderController : Controller
    {
        private readonly IProviderService _providerService;

        public ProviderController(IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public Provider Get(int id) => _providerService.Get(id);

        [HttpPost("save")]
        public Provider Save(Provider request) => _providerService.Save(request);

        [HttpGet("search")]
        public IEnumerable<Provider> Search(string query) => _providerService.GetFiltered(query);

        [HttpDelete("delete")]
        public void Delete(int id) => _providerService.Delete(id);
    }
}
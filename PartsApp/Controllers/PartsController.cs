using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PartsApplication;

namespace PartsApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PartsController : ControllerBase
    {
        private readonly ILogger<PartsController> _logger;
        private readonly IPartsApplication _partsApp;

        public PartsController(ILogger<PartsController> logger,
            IPartsApplication partsApp)
        {
            _logger = logger;
            _partsApp = partsApp;
        }

        [HttpGet]
        public IActionResult Get(string partNumber)
        {
            var part = _partsApp.GetPart(partNumber);
            return Ok(part);
        }
    }
}

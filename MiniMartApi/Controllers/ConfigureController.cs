using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Minimart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigureController : ControllerBase
    {
        private readonly IConfigureServices _configureServices;
        // GET: api/<StoresController>
        public ConfigureController(IConfigureServices configureServices)
        {
            _configureServices = configureServices;
        }

        /// <summary>
        /// Setup all data  
        /// </summary>
        [HttpGet]
        public void Get()
        {
             _configureServices.initModel();
        }
    }
}

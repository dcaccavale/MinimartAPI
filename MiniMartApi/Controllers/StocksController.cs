using Core.Infrastructure;
using Core.Interfaces;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minimart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IStocksServices _stockServices;
        // GET: api/<StoresController>
        public StocksController(IStocksServices stockServices)
        {
            _stockServices = stockServices;
        }

        [HttpGet]
        public IEnumerable<StocksResponse> GetAllAbly()
        {
            return _stockServices.GetAllAbly();
        }
        [HttpGet("{productId, storedId}")]
        public StocksResponse GetByPrductAndStore(Guid productID , Guid storeId)
        {
            return _stockServices.GetByPrductAndStore(productID, storeId);
        }
    }
}

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
        public IEnumerable<StocksResponse> GetAllAvailable()
        {
            return _stockServices.GetAllAvailable();
        }
        [HttpGet("/store/{storedId}/product/{productId}")]
        public StocksResponse GetByPrductAndStore(Guid productID , Guid storeId)
        {
            return _stockServices.GetByPrductAndStore(productID, storeId);
        }

        [HttpGet("/store/{storedId}")]
        public IEnumerable<StocksResponse> GetAllAvailableByStore(Guid storeId)
        {
            return _stockServices.GetAllAvailableByStore(storeId);
        }
        
    }
}

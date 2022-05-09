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
        /// <summary>
        /// Be able to query all available products, across stores, with their total stock
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<StocksResponse> GetAllAvailable()
        {
            return _stockServices.GetAllAvailable();
        }

        /// <summary>
        /// Be able to query available products for a particular store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        [HttpGet("{storedId,productId}")]
        public StocksResponse GetByPrductAndStore(Guid productID , Guid storeId)
        {
            return _stockServices.GetByPrductAndStore(productID, storeId);
        }
        /// <summary>
        ///  Be able to query available products for a particular store
        /// </summary>
        /// <param name="storeId">Store Id</param>
        /// <returns></returns>
        [HttpGet("/store/{storedId}")]
        public Task<IEnumerable<StocksResponse>> GetAllAvailableByStore(Guid storeId)
        {
            return _stockServices.GetAllAvailableByStore(storeId);
        }
        
    }
}

using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Minimart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoucherController : ControllerBase
    {
        private readonly IStoreServices _storeServices;
        // GET: api/<StoresController>
        public VoucherController(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }
        /// <summary>
        /// Validate a voucher by code voucher and storeId
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        // GET api/<StoresController>/5
        [HttpGet("{id}")]
        public Task<bool> IsValid(string voucherCode, Guid storeID)
        {
            return null;
        }

        [HttpGet("{id}")]
        public Task<bool> CalculateDiscount(string voucherCode, Guid productId)
        {
            return null;
        }
    }
}

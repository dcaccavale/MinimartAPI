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
        private readonly IVoucherServices _voucherServices;
        // GET: api/<StoresController>
        public VoucherController(IVoucherServices voucherServices)
        {
            _voucherServices = voucherServices;
        }
        /// <summary>
        /// Validate a voucher by code voucher and storeId
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <returns></returns>
        // GET api/<StoresController>/5
        [HttpGet("api/validate-{voucherCode,storeId}")]
        public Task<bool> IsValid(string voucherCode, Guid storeId)
        {
            return _voucherServices.ValidateByCode(voucherCode, storeId);
        }

        [HttpGet("{voucherCode}/product{productId}")]
        public Task<bool> CalculateDiscount(string voucherCode, Guid productId)
        {
            return null;
        }
    }
}

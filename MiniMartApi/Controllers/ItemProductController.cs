using Core.Infrastructure;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Minimart_API.ViewModel;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Minimart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemProductController : ControllerBase
    {
        private readonly ICartServices _cartServices;

        public ItemProductController(ICartServices cartServices)
        {
            _cartServices = cartServices;
        }
        /// <summary>
        /// Add an item to cart if stock is available
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Task<ItemProductResponse> Post([FromBody] ItemProductRequest itemProductRequest)
        {
            return _cartServices.AddItemProduct(itemProductRequest.ProductId, itemProductRequest.CartId, itemProductRequest.Quantity, itemProductRequest.VoucherCode);
        }

        /// <summary>
        /// Remove an item from the cart and update the available stock
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public Task<ItemProductResponse> Delete([FromBody] ItemProductRequest itemProductRequest)
        {
            return _cartServices.DeleteItemProduct(itemProductRequest.ProductId, itemProductRequest.CartId);

        }

    }
}

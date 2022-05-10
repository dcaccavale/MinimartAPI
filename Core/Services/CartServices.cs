using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;
using Microsoft.Extensions.Logging;
using System.Transactions;

namespace Core.Services
{
    public  class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IItemProductRepository _itemProductRepository;
        private readonly ILogger<Cart> _logger;
        private readonly IMapper _mapper;
        public CartServices(ICartRepository cartRepository, IStockRepository stockRepository, IItemProductRepository itemProductRepository, ILogger<Cart> logger, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _stockRepository = stockRepository;
            _itemProductRepository = itemProductRepository;
            _logger = logger;
            _mapper = mapper;
        }
        /// <summary>
        /// Add an item to cart if stock is available
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cartId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<ItemProductResponse> AddItemProduct(Guid productId, Guid cartId, int quantity)
        {
            var cart = await _cartRepository.GetAsync(cartId);
            if(cart != null) 
            {
                var stock = _stockRepository.GetByStoreAndProduct(productId, cart.Store.Id).Result;
                if (stock != null && stock.Quantity >= quantity)
                {
                    ItemProduct itemProduct = new ItemProduct()
                    {
                        PriceUnit = stock.Product.Price,
                        Product = stock.Product,
                        Quantity = quantity,
                        Cart = cart,
                        TotalAmound = stock.Product.Price * quantity
                    };
                    //Add Item to repository
                    itemProduct = await _itemProductRepository.Add(itemProduct);
                    //Update Stock to repository
                    stock.Quantity -= quantity;
                    stock = await _stockRepository.Update(stock);

                    return new ItemProductResponse()
                    {
                        Quantity = itemProduct.Quantity,
                        ProductId = productId,
                        StoreId = stock.Store.Id,
                        CartID = cartId,
                        UnitPrice = itemProduct.PriceUnit,
                        AmoundTotal = itemProduct.TotalAmound,
                        ProductName = itemProduct.Product.Name
                    };
                }
            }
            
            return null;
        }


        /// <summary>
        /// Remove an item from the cart and update the available stock
        /// </summary>
        /// <param name="itemProduct"></param>
        /// <returns></returns>
        public async Task<ItemProductResponse> DeleteItemProduct(Guid productId, Guid cartId)
        {
        
                var cart = await _cartRepository.GetAsync(cartId);
                if (cart != null)
                {
                    var stock = await _stockRepository.GetByStoreAndProduct(productId, cart.Store.Id);
                    var itemProduct = await _itemProductRepository.GetByProductAndCartAsync(productId, cartId);
                    if (itemProduct != null && stock != null)
                    {
                        stock.Quantity += itemProduct.Quantity;
                        //Delete Stock to repository
                        var itemDeleted = _itemProductRepository.Delete(itemProduct);
                   
                        if (itemDeleted == null) return null;
                        return new ItemProductResponse()
                        {
                            Quantity = itemProduct.Quantity,
                            ProductId = productId,
                            StoreId = stock.Store.Id,
                            CartID = cartId,
                            UnitPrice = itemProduct.PriceUnit,
                            AmoundTotal = itemProduct.PriceUnit * itemProduct.Quantity,
                            ProductName = itemProduct.Product.Name
                        };
                    }
                }

                return null;
          
        }

    }
}

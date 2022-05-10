﻿using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;

namespace Core.Services
{
    public  class CartServices : ICartServices
    {
        private readonly ICartRepository _cartRepository;
        private readonly IStockRepository _stockRepository;
        private readonly IItemProductRepository _itemProductRepository;
        public CartServices(ICartRepository cartRepository, IStockRepository stockRepository, IItemProductRepository itemProductRepository)
        {
            _cartRepository = cartRepository;
            _stockRepository = stockRepository;
            _itemProductRepository = itemProductRepository;
        }
        /// <summary>
        /// Add an item to cart if stock is available
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cartId"></param>
        /// <param name="Amound"></param>
        /// <returns></returns>
        public async Task<ItemProductResponse> AddItemProduct(Guid productId, Guid cartId, int Amound)
        {
            var cart = await _cartRepository.GetAsync(cartId);
            var stock = _stockRepository.GetByStoreAndProduct(productId,cart.Store.Id).Result;
            if (stock != null && stock.Quantity >= Amound)
            {
                ItemProduct itemProduct = new ItemProduct() { 
                    PriceUnit= stock.Product.Price,
                    Product = stock.Product,
                    Quantity = Amound
                };
                //Add Item to repository
                await _itemProductRepository.Add(itemProduct);
                //Update Stock to repository
                stock.Quantity -= Amound;
                await _stockRepository.Update(stock); 

                return new ItemProductResponse() { 
                 Quantity = itemProduct.Quantity,
                 ProductId = productId, 
                 StoreId  = stock.Store.Id, 
                 CartID= cartId,
                 UnitPrice= itemProduct.PriceUnit,
                 AmoundTotal = itemProduct.PriceUnit * itemProduct.Quantity,
                 ProductName= itemProduct.Product.Name
                };
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
            var stock = await _stockRepository.GetByStoreAndProduct(productId, cart.Store.Id);
            var itemProduct = await _itemProductRepository.GetByProductAndCartAsync(productId, cartId);
            if (itemProduct != null && stock != null)
            {
                stock.Quantity += itemProduct.Quantity;
                //Delete Stock to repository
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
            return null;
        }

    }
}

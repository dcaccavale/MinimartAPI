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
        private readonly IVoucherRepository _voucherRepository;
        private readonly ILogger<Cart> _logger;
        private readonly IMapper _mapper;
        public CartServices(ICartRepository cartRepository, IStockRepository stockRepository, IItemProductRepository itemProductRepository,IVoucherRepository voucherRepository ,ILogger<Cart> logger, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _stockRepository = stockRepository;
            _itemProductRepository = itemProductRepository;
            _voucherRepository = voucherRepository;
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
        public async Task<ItemProductResponse> AddItemProduct(Guid productId, Guid cartId, int quantity, string ? voucherCode)
        {
            var cart = await _cartRepository.GetAsync(cartId);
            if(cart != null) 
            {
                var stock = _stockRepository.GetByStoreAndProduct(productId, cart.Store.Id).Result;
                if (stock != null && stock.Quantity >= quantity)
                {
                    Voucher? voucher = null;
                    if (voucherCode != null)
                         voucher = await _voucherRepository.GetOneByCodeAsync(voucherCode);

                    ItemProduct itemProduct = new ItemProduct()
                    {
                        PriceUnit = stock.Product.Price,
                        Product = stock.Product,
                        Quantity = quantity,
                        Cart = cart,
                    };
                    itemProduct.TotalDiscount = (voucher != null) ? voucher.CalculateDiscount(itemProduct, DateTime.Now) : 0;
                    itemProduct.TotalAmound =stock.Product.Price * quantity - itemProduct.TotalDiscount;
                    //Add Item to repository
                    itemProduct = await _itemProductRepository.Add(itemProduct);
                    //Update Stock to repository
                    stock.Quantity -= quantity;
                    stock = await _stockRepository.Update(stock);
                    return _mapper.Map<ItemProduct, ItemProductResponse>(itemProduct);
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
                        var itemDeleted = await _itemProductRepository.Delete(itemProduct);
                   
                        if (itemDeleted == null) return null;
                        return _mapper.Map<ItemProduct, ItemProductResponse>(itemDeleted);
                }
                }

                return null;
          
        }

    }
}

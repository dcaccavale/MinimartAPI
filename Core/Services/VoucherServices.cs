using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class VoucherServices : IVoucherServices
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<Voucher> _logger;
        private readonly IMapper _mapper;

        public VoucherServices(IVoucherRepository voucherRepository, IProductRepository productRepository, IStoreRepository storeRepository, ILogger<Voucher> logger, IMapper mapper)
        {
            _voucherRepository = voucherRepository;
            _productRepository = productRepository;
            _storeRepository = storeRepository;
            _logger = logger;
            _mapper = mapper;
        }


        /// <summary>
        /// Validate voucher by code and store
        /// </summary>
        /// <param name="code"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<bool> ValidateByCode(string code, Guid storeId)
        {
            var voucher = await _voucherRepository.GetAsync(code, storeId);

            //Invalid Code 
            if (voucher == null) return false;
            var store = await _storeRepository.GetAsync(storeId);
            // apply to the store
            return voucher.Validate(DateTime.Now, store);
        }

        /// <summary>
        /// calculate discount to a product applying a valid code
        /// </summary>
        /// <param name="voucherId"></param>
        /// <param name="productId"></param>
        /// <param name="CartId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<ItemProductResponse?> CalculateDiscount(Guid voucherId, Guid productId, Guid CartId, int quantity)
        {
            Voucher? voucher = await _voucherRepository.GetAsync(voucherId);
            //Invalid Code 
            if (voucher == null || !voucher.Validate(DateTime.Now, voucher.Store)) return null;
            // apply to the store
            Product? product = await _productRepository.GetAsync(productId);
            var itemProductToAdd = new ItemProduct() { Product = product, Quantity = quantity, PriceUnit = product.Price };
            var discount = voucher.CalculateDiscount(itemProductToAdd, DateTime.Now);

            return new ItemProductResponse()
            {
                CartID = CartId,
                Quantity = quantity,
                AmoundTotal = itemProductToAdd.TotalAmound,
                DiscountTotal = discount,
                UnitPrice = product.Price,
                ProductId = product.Id
            };
        }


        /// <summary>
        /// calculate discount to a product, applying a valid code
        /// </summary>
        /// <param name="voucherCode"></param>
        /// <param name="productId"></param>
        /// <param name="CartId"></param>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public async Task<ItemProductResponse> CalculateDiscount(string voucherCode, Guid productId, Guid CartId, int quantity)
        {
            Voucher voucher = await _voucherRepository.GetOneByCodeAsync(voucherCode);
            //Invalid Code 
            if (voucher == null || !voucher.Validate(DateTime.Now, voucher.Store)) return new ItemProductResponse();
            
            // apply to the store
            Product? product = await _productRepository.GetAsync(productId);
            ItemProduct itemProductToAdd = new ItemProduct() { 
                Product = product, 
                Quantity = quantity, 
                PriceUnit = product.Price,
                VoucherAppled = voucher,
                TotalAmound = product.Price * quantity,
                TotalDiscount = 0,
                Cart= new Cart() { Id = CartId }
            };
            itemProductToAdd.TotalDiscount = voucher.CalculateDiscount(itemProductToAdd, DateTime.Now);
            return _mapper.Map<ItemProduct, ItemProductResponse>(itemProductToAdd);


        }
    } 

}

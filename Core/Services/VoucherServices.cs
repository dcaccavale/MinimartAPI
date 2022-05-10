using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class VoucherServices :IVoucherServices
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IProductRepository  _productRepository;
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<Voucher> _logger;
        private readonly IMapper _mapper;

        public VoucherServices(IVoucherRepository voucherRepository, IProductRepository productRepository, IStoreRepository storeRepository, ILogger<Voucher> logger, IMapper mapper)
         {
            _voucherRepository = voucherRepository;
            _productRepository = productRepository;
            _storeRepository   = storeRepository;
            _logger = logger;
            _mapper = mapper;
          }

        public async Task<bool> ValidateByCode(string code, Guid storeId)
        {
            var voucher = await _voucherRepository.GetAsync(code, storeId);
            var store = await _storeRepository.GetAsync(storeId);
            //Invalid Code 
            if (voucher == null) return false;
            // apply to the store
            return  voucher.Validate(DateTime.Now, store);
        }
        public async Task<ItemProductResponse?> CalculateDiscount(Guid voucherId, Guid productId, Guid CartId, int quantity)
        {
            Voucher? voucher =  await _voucherRepository.GetAsync(voucherId);
            //Invalid Code 
            if (voucher == null || !voucher.Validate(DateTime.Now, voucher.Store)) return null;
            // apply to the store
            Product? product = await _productRepository.GetAsync(productId);
            var itemProductToAdd = new ItemProduct() { Product= product, Quantity=  quantity, PriceUnit=product.Price  };
            var discount = voucher.CalculateDiscount(itemProductToAdd,DateTime.Now);

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


    }
}

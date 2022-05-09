using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class VoucherServices
    {
        private readonly IVoucherRepository _voucherRepository;
        private readonly IProductRepository  _productRepository;
         public VoucherServices(IVoucherRepository voucherRepository, IProductRepository productRepository)
         {
            _voucherRepository = voucherRepository;
            _productRepository = productRepository;
          }

        public Task<bool> ValidateByCode(string code, Guid storeId)
        {
            var voucher = _voucherRepository.GetVoucher(code, storeId);
            return null;
        }
    }
}

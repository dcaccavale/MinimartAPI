using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VoucherRepository : GenericRepository, IVoucherRepository
    {
        public VoucherRepository(MinimarketDataContext dataContext) : base(dataContext)
        {
        }

        public  Task<Voucher?> GetVoucher(string code, Guid storeId)
        {
            return  base.FirstOrDefaultAsync<Voucher>(v => v.Code == code && v.Store.Id == storeId);
        }

    }
}

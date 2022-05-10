using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class VoucherRepository : GenericRepository, IVoucherRepository
    {
        public VoucherRepository(MinimarketDataContext dataContext) : base(dataContext)
        {
        }

        public  Task<Voucher?> GetAsync(string code, Guid storeId)
        {
            return  base.FirstOrDefaultAsync<Voucher>(v => v.Code == code && v.Store.Id == storeId);
        }
        public Task<Voucher?> GetAsync(Guid Id)
        {
            return _dataContext.Vouchers.Where(P => P.Id == Id).Include(p => p.Discount).Include(p => p.RangeDate).Include(p => p.Store).FirstOrDefaultAsync();
        }

    }
}

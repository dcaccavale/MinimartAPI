using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
            return  base.FirstOrDefaultAsync<Voucher>(v => v.Code == code && v.Store.Id == storeId, p => p.Include(p => p.Discount).Include(p => p.RangeDate).Include(p => p.Store));
        }
        public  Task<Voucher?> GetAsync(Guid Id)
        {
            return  base.GetAsync<Voucher>(Id, p=>p.Include(p=> p.Discount).Include(p => p.RangeDate).Include(p => p.Store));
        }

        public async Task<Voucher?> GetOneByCodeAsync(string voucherCode)
        {
            var result = await base.FirstOrDefaultAsync<Voucher>(p=>p.Code== voucherCode);
            if (result is VoucherCategory)
            {
                return await base.FirstOrDefaultAsync<VoucherCategory>(v => v.Code == voucherCode,
                    p => p.Include(p => p.Store).Include(p => p.Discount).Include(p => p.RangeDate)
                    .Include(p => p.ExceptedDiscountProduct).Include(p => p.CategoriesToApply));
            }
            else {
                return await base.FirstOrDefaultAsync<VoucherProduct>(v => v.Code == voucherCode,
                 p => p.Include(p => p.Store).Include(p => p.Discount).Include(p => p.RangeDate)
                 .Include(p => p.ProductToApply));

            }

        }

        public Task<Voucher?> GetOneByCriteriaAsync(Expression<Func<Voucher, bool>> predicate = null, Func<IQueryable<Voucher>, IIncludableQueryable<Voucher, object>> include = null)
        {
            return base.FirstOrDefaultAsync(predicate, include);
        }
    }
}

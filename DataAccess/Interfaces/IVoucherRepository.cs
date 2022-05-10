using Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IVoucherRepository 
    {
        Task<Voucher?> GetAsync(string code, Guid storeId);

        Task<Voucher?> GetAsync(Guid voucherId);
        Task<Voucher?> GetOneByCriteriaAsync(Expression<Func<Voucher, bool>> predicate = null,
            Func<IQueryable<Voucher>, IIncludableQueryable<Voucher, object>> include = null);

        Task<Voucher?> GetOneByCodeAsync(string voucherCode);
    }
}
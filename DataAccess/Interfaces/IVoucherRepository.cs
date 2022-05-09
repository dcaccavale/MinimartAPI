using Entities;

namespace DataAccess.Interfaces
{
    public interface IVoucherRepository
    {
        Task<Voucher?> GetVoucher(string code, Guid storeId);
    }
}
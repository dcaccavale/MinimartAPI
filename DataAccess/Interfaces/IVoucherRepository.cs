using Entities;

namespace DataAccess.Interfaces
{
    public interface IVoucherRepository
    {
        Task<Voucher?> GetAsync(string code, Guid storeId);
        Task<Voucher?> GetAsync(Guid Id);
      
    }
}
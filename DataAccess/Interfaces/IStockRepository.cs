using Entities;

namespace DataAccess.Interfaces
{
    public interface IStockRepository
    {
        Task<StockProduct?> GetByStoreAndProduct(Guid productID, Guid storeId);
        Task<IEnumerable<StockProduct>> GetAllAsync();
        Task<IEnumerable<StockProduct>> GetAllAblyAsync();
    }
}
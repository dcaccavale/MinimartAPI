using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface IStocksServices
    {
        Task<IEnumerable<StocksResponse>?> GetAllAvailable();
        Task<StocksResponse?> GetByPrductAndStore(Guid productID, Guid storeId);

        Task<IEnumerable<StocksResponse>?> GetAllAvailableByStore(Guid storeId);
    }
}
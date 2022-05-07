using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface IStocksServices
    {
        IEnumerable<StocksResponse> GetAllAvailable();
        StocksResponse? GetByPrductAndStore(Guid productID, Guid storeId);

        IEnumerable<StocksResponse> GetAllAvailableByStore(Guid storeId);
    }
}
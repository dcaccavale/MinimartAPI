using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface IStocksServices
    {
        IEnumerable<StocksResponse> GetAllAvailable();
        StocksResponse? GetByPrductAndStore(Guid productID, Guid storeId);

        Task<IEnumerable<StocksResponse>> GetAllAvailableByStore(Guid storeId);
    }
}
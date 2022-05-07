using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface IStocksServices
    {
        IEnumerable<StocksResponse> GetAllAbly();
        StocksResponse? GetByPrductAndStore(Guid productID, Guid storeId);
    }
}
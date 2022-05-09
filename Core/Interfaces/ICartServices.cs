using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface ICartServices
    {
        Task<ItemProductResponse> AddItemProduct(Guid productId, Guid cartId, int Amound);
        Task<ItemProductResponse> DeleteItemProduct(Guid productId, Guid cartId);

    }
}
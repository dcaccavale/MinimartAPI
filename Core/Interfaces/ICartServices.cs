using Core.Infrastructure;

namespace Core.Interfaces
{
    public interface ICartServices
    {
        Task<ItemProductResponse> AddItemProduct(Guid productId, Guid cartId, int Quantity, string? voucherCode);
        Task<ItemProductResponse> DeleteItemProduct(Guid productId, Guid cartId);

    }
}
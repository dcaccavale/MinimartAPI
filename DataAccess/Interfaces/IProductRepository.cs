using Entities;

namespace DataAccess.Interfaces
{
    public interface IProductRepository
    {
        Task<Product?> GetAsync(Guid Id);
    }
}
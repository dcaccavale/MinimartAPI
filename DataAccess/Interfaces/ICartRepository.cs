using Entities;

namespace DataAccess.Interfaces
{
    public interface ICartRepository
    {
        Task<Cart?> GetAsync(Guid Id);
    }
}
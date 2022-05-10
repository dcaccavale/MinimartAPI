using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class ProductRepository : GenericRepository , IProductRepository
    {
        public ProductRepository(MinimarketDataContext dataContext) : base(dataContext)
        {
        }
        public Task<Product> GetAsync(Guid Id)
        {
            return base.GetAsync<Product>(Id);
        }

    }
}

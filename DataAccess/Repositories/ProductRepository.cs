using DataAccess.Interfaces;
using Entities;

namespace DataAccess.Repositories
{
    public class ProductRepository : GenericRepository , IProductRepository
    {
        public ProductRepository(MinimarketDataContext dataContext) : base(dataContext)
        {
        }
        /// <summary>
        /// Gets product by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Product?> GetAsync(Guid Id)
        {
            return base.GetAsync<Product>(Id);
        }

    }
}

using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    internal class CartRepository : GenericRepository, ICartRepository
    {
        public CartRepository(MinimarketDataContext dataContext) : base(dataContext)
        {

        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return base.GetAllAsync<Cart>();
        }

        public Task<Cart> GetAsync(Guid Id)
        {
            return base.GetAsync<Cart>(Id);
        }
    }
}

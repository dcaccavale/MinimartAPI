using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class ItemProductRepository : GenericRepository, IItemProductRepository
    {
        public ItemProductRepository(MinimarketDataContext dataContext) : base(dataContext) { }

        public Task<ItemProduct> Add(ItemProduct itemProduct)
        {
            return base.Add(itemProduct);
        }

        public Task<ItemProduct> GetByProductAndCartAsync(Guid productId, Guid cartId)
        {
            return base.FirstOrDefaultAsync<ItemProduct>(p => p.Product.Id == productId && p.Cart.Id == cartId);
        }
    }
}

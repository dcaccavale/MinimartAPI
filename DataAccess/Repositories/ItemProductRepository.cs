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


        /// <summary>
        /// Add item Producto to cart
        /// </summary>
        /// <param name="itemProduct"></param>
        /// <returns></returns>
        public Task<ItemProduct> Add(ItemProduct itemProduct)
        {
            return base.Add(itemProduct);
        }

        /// <summary>
        /// Delete itemProduct
        /// </summary>
        /// <param name="itemProduct"></param>
        /// <returns></returns>
        public Task<ItemProduct?> Delete(ItemProduct itemProduct)
        {
            return base.Delete(itemProduct);
        }

        /// <summary>
        /// Gat ItemProduct by cart and product 
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="cartId"></param>
        /// <returns></returns>
        public  Task<ItemProduct?> GetByProductAndCartAsync(Guid productId, Guid cartId)
        {
            return  base.FirstOrDefaultAsync<ItemProduct>(p => p.Product.Id == productId && p.Cart.Id == cartId);
        }
    }
}

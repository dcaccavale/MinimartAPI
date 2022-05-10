using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class StocksRepository :GenericRepository, IStockRepository
    {
        public StocksRepository(MinimarketDataContext dataContext) : base(dataContext) { }


        /// <summary>
        /// Gets available stock by store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StockProduct>?> GetAllAvailableAsync()
        {
            return await base.GetAllAsync<StockProduct>(
                p => p.Quantity > 0,null,null, P=> P.Include(p => p.Product.Category)
                );
        }
        /// <summary>
        /// Gets all stock 
        /// </summary>
        /// <returns></returns>
        public Task<IEnumerable<StockProduct>> GetAllAsync()
        {
           return base.GetAllAsync<StockProduct>();
        }

        /// <summary>
        /// Get available stock by store 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StockProduct>?> GetAllAvailableByStore(Guid storeId)
        {
            return await base.GetAllAsync<StockProduct>(
          p => p.Store.Id == storeId && p.Quantity > 0, null, null, P => P.Include(p => p.Product.Category).Include(p=> p.Store)
           );
       }

       
        /// <summary>
        /// Gets stock by store and product
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<StockProduct?> GetByStoreAndProduct(Guid productID, Guid storeId)
        {
            return await base.FirstOrDefaultAsync<StockProduct>(
               p => p.Product.Id == productID && p.Store.Id == storeId, p=> p.Include(p => p.Product.Category)
                );
        }

        /// <summary>
        /// Update stock producto
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public Task<StockProduct?> Update(StockProduct stock)
        {
            return base.Update(stock);
        }
    }
}

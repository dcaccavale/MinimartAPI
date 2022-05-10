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



        public async Task<IEnumerable<StockProduct>> GetAllAvailableAsync()
        {
            return await _dataContext.StockProducts.Where(p => p.Quantity > 0).Include(p => p.Product.Category).ToListAsync();
        }

        public Task<IEnumerable<StockProduct>> GetAllAsync()
        {
           return base.GetAllAsync<StockProduct>();
        }

        public async Task<IEnumerable<StockProduct>> GetAllAvailableByStore(Guid storeId)
        {
            return await _dataContext.StockProducts.Where(p => p.Store.Id == storeId && p.Quantity > 0).Include(p => p.Product.Category).ToListAsync();
          
        }

        public Task<StockProduct?> GetAsync(Guid Id)
        {
            return base.GetAsync<StockProduct>(Id);
        }

        public Task<StockProduct?> GetByStoreAndProduct(Guid productID, Guid storeId)
        {
            return _dataContext.StockProducts.Where(p => p.Product.Id == productID && p.Store.Id == storeId).Include(p => p.Product.Category).FirstOrDefaultAsync();

        }


        Task<StockProduct> IStockRepository.Update(StockProduct stock)
        {
            return base.Update(stock);
        }
    }
}

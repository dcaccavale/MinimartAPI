using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repositories
{
    public  class StoreRepository : GenericRepository , IStoreRepository
    {
        public StoreRepository(MinimarketDataContext dataContext) : base(dataContext)
        {

        }

        public async Task<IEnumerable<Store>?> GetAllAsync()
        {
            return await base.GetAllAsync<Store>();
        }

        public async Task<IEnumerable<Store>?> GetAllWhitDailyTimeRange()
        {
            return await _dataContext.Stores.AsQueryable().Include(s=> s.DailyTimeRange).ToListAsync();
        }

        public async Task<Store?> GetAsync(Guid Id)
        {
            return await base.GetAsync<Store>(Id, p=>p.Include(c=>c.DailyTimeRange) );
        }
    }
}

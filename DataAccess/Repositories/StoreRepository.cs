using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public  class StoreRepository : GenericRepository , IStoreRepository
    {
        public StoreRepository(MinimarketDataContext dataContext) : base(dataContext)
        {

        }

        public Task<IEnumerable<Store>> GetAllAsync()
        {
            return  base.GetAllAsync<Store>();
        }

        public Task<Store> GetAsync(Guid Id)
        {
            return base.GetAsync<Store>(Id);
        }
    }
}

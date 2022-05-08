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

        public Task<IEnumerable<Store>> GetAllAsync()
        {
            return  base.GetAllAsync<Store>();
        }

        public Task<IEnumerable<Store>> GetAllAsync(Expression<Func<Store, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Store>> GetAllAvailable(DateTime dateTime)
        {
            throw new NotImplementedException();
        }

        public Task<Store> GetAsync(Guid Id)
        {
            return base.GetAsync<Store>(Id);
        }
    }
}

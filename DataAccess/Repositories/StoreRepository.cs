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

        public IEnumerable<Store> GetAllAvailable(DayOfWeek dayOfWeek , TimeSpan time)
        {
            return  base.GetAllAsync<Store>().Result.Where(s => s.IsOpen(time, dayOfWeek));
        }

        public Task<Store> GetAsync(Guid Id)
        {
            return base.GetAsync<Store>(Id);
        }
    }
}

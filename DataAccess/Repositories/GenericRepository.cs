using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public  class GenericRepository
    {
        protected readonly MinimarketDataContext _dataContext;
        public GenericRepository(MinimarketDataContext dataContext)
        {
            _dataContext = dataContext;

           
        }
        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : class
        {
            
            var query = _dataContext.Set<T>().AsQueryable();
            return await query.ToListAsync();
        }
        public async Task<T> GetAsync<T>(Guid Id) where T : Entity
        {

            return await _dataContext.Set<T>().AsQueryable().SingleOrDefaultAsync(s=> s.Id == Id);
            
            
        }
    }
}

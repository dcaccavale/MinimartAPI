using DataAccess.Interfaces;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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

        public async Task<IEnumerable<T>> GetAllAsync<T>(Expression<Func<T, bool>> predicate = null) where T : class
        {

            var query = _dataContext.Set<T>().AsQueryable();
            return await query.Where<T>(predicate).ToListAsync();
        }


        public async Task<T?> GetAsync<T>(Guid Id) where T : Entity
        {
            return await _dataContext.Set<T>().AsQueryable().SingleOrDefaultAsync(s=> s.Id == Id);   
        }
        public async Task<T?> FirstOrDefaultAsync<T>(Expression<Func<T, bool>> predicate = null) where T : Entity
        {
            return await _dataContext.Set<T>().AsQueryable().FirstOrDefaultAsync(predicate);
        }

        public async Task<T> Add<T>(T entity) where T : Entity
        {
            _dataContext.Set<T>().Add(entity);
            return await _dataContext.Set<T>().AsQueryable().SingleOrDefaultAsync(e=> e.Id == entity.Id);
        }

        public async Task<T> Update<T>(T entity) where T : Entity
        {
            _dataContext.Set<T>().Update(entity);
            return await _dataContext.Set<T>().AsQueryable().SingleOrDefaultAsync(e => e.Id == entity.Id);
        }

    }
}

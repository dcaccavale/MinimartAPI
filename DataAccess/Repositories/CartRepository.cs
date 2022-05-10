using DataAccess.Interfaces;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
namespace DataAccess.Repositories
{
    public  class CartRepository : GenericRepository, ICartRepository
    {
        public CartRepository(MinimarketDataContext dataContext) : base(dataContext)
        {

        }

        public Task<IEnumerable<Cart>> GetAllAsync()
        {
            return base.GetAllAsync<Cart>();
        }
        /// <summary>
        /// Gets cart by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<Cart?> GetAsync(Guid Id)
        {
            return  _dataContext.Carts.Include(c=> c.Store).FirstOrDefaultAsync(c=> c.Id == Id) ;
        }
    }
}

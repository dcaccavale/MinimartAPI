using Entities;
using System.Linq.Expressions;

namespace DataAccess.Interfaces
{
    public interface IGenericRepository <T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync() ;

        Task<T> GetAsync(Guid Id);

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate);
    }
}
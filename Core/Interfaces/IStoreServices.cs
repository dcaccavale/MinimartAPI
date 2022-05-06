using Core.Infrastructure;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStoreServices
    {
        Task<IEnumerable<StoreResponse>> GetAllAsync();
        Task<StoreResponse> GetAsync(Guid Id);
    }
}

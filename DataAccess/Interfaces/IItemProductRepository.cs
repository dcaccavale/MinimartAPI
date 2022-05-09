using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IItemProductRepository
    {
        Task<ItemProduct> Add(ItemProduct itemProduct);
        Task<ItemProduct> GetByProductAndCartAsync(Guid productId, Guid cartId);
    }
}

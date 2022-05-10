using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IVoucherServices
    {
        Task<bool> ValidateByCode(string code, Guid storeId);
    }
}

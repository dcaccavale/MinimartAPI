using DataAccess.Repositories;
using Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public  class CartService : ICartServices
    {
        private readonly ICartRepository _Repository;
        private readonly ILogger<Cart> _logger;


    }
}

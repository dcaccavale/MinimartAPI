using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
 
    public  class StoreResponse
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }    
    }
}

using AutoMapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Infrastructure
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {

            CreateMap<Store, StoreResponse>();

        }
    }
}

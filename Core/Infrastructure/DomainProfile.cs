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
/// <summary>
/// Configure mapper
/// </summary>
        private void CreateMaps()
        {

            CreateMap<Store, StoreResponse>();
            CreateMap<StockProduct, StocksResponse>()
                .ForMember(des=> des.ProductName ,m=> m.MapFrom(sourse=> sourse.Product.Name))
                .ForMember(des => des.Quantity, m => m.MapFrom(sourse => sourse.Quantity))
                .ForMember(des => des.ProductId, m => m.MapFrom(sourse => sourse.Product.Id))
                .ForMember(des => des.ProductCategory , m => m.MapFrom(sourse => sourse.Product.Category.Description))
                .ForMember(des => des.StoreId, m => m.MapFrom(sourse => sourse.Store.Id))
                .ForMember(des => des.StoreName, m => m.MapFrom(sourse => sourse.Store.Name))

                ;

            /*
                 //BranchCollege
                CreateMap<BranchCollege, BranchCollegeViewModel>();
                CreateMap<PostBranchCollegeViewModel, BranchCollege>();
                CreateMap<BranchCollege, PostBranchCollegeViewModel>()
                .ForMember(dest => dest.CareersIds, m => m.MapFrom(source => source.CareerBranchColleges.Select(cbc => cbc.Career.Id.ToString())));
             */

        }
    }
}

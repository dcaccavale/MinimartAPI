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
                .ForMember(des => des.ProductName, m => m.MapFrom(sourse => sourse.Product.Name))
                .ForMember(des => des.Quantity, m => m.MapFrom(sourse => sourse.Quantity))
                .ForMember(des => des.ProductId, m => m.MapFrom(sourse => sourse.Product.Id))
                .ForMember(des => des.ProductCategory, m => m.MapFrom(sourse => sourse.Product.Category.Description))
                .ForMember(des => des.StoreId, m => m.MapFrom(sourse => sourse.Store.Id))
                .ForMember(des => des.StoreName, m => m.MapFrom(sourse => sourse.Store.Name));
                
            CreateMap<ItemProduct, ItemProductResponse>()
                .ForMember(des => des.ProductName, m => m.MapFrom(sourse => sourse.Product.Name))
                .ForMember(des => des.Quantity, m => m.MapFrom(sourse => sourse.Quantity))
                .ForMember(des => des.ProductId, m => m.MapFrom(sourse => sourse.Product.Id))
                .ForMember(des => des.UnitPrice, m => m.MapFrom(sourse => sourse.Product.Price))
                .ForMember(des => des.CartID, m => m.MapFrom(sourse => sourse.Cart.Id))
                .ForMember(des => des.AmoundTotal, m => m.MapFrom(sourse => (sourse.PriceUnit * sourse.Quantity)))
                .ForMember(des => des.DiscountTotal, m => m.MapFrom(sourse => sourse.TotalDiscount))
                .ForMember(des => des.AmoundTotalWhitDiscount, m => m.MapFrom(sourse => (sourse.TotalAmound - sourse.TotalDiscount)));
                       


        }
    }
}

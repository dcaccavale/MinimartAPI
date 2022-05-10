using Core.Interfaces;
using Core.Services;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Minimart_API
{
    public static class IoCServices
    {
        public static IServiceCollection AddDependency(this IServiceCollection services)
        {
            // Inyect Repository
            services.AddTransient(typeof(IItemProductRepository), typeof(ItemProductRepository));
            services.AddTransient(typeof(IStoreRepository), typeof(StoreRepository));
            services.AddTransient(typeof(IConfigureRepository), typeof(ConfigureRepository));
            services.AddTransient(typeof(IStockRepository), typeof(StocksRepository));
            services.AddTransient(typeof(ICartRepository), typeof(CartRepository));
            services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
            services.AddTransient(typeof(IVoucherRepository), typeof(VoucherRepository));
            services.AddTransient(typeof(IProductRepository), typeof(ProductRepository));
            //Inject Services
            services.AddTransient(typeof(IStoreServices), typeof(StoreServices));
            services.AddTransient(typeof(IConfigureServices), typeof(ConfigureServices));
            services.AddTransient(typeof(IStocksServices), typeof(StocksServices));
            services.AddTransient(typeof(ICartServices), typeof(CartServices));
            services.AddTransient(typeof(IVoucherServices), typeof(VoucherServices));

            return services;
        }
    }
}

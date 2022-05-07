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
            // Inyectar los servicios del repositorio génerico
            services.AddTransient(typeof(IStoreRepository), typeof(StoreRepository));
            services.AddTransient(typeof(IStoreServices), typeof(StoreServices));
            
            services.AddTransient(typeof(IConfigureServices), typeof(ConfigureServices));
            services.AddTransient(typeof(IConfigureRepository), typeof(ConfigureRepository));
          
            services.AddTransient(typeof(IStocksServices), typeof(StocksServices));
            services.AddTransient(typeof(IStockRepository), typeof(StocksRepository));
            return services;
        }
    }
}

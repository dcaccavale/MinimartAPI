using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class StocksServices : IStocksServices
    {
        private readonly IStockRepository _stockRepository;
        private readonly ILogger<StocksResponse> _logger;

        private readonly IMapper _mapper;

        public StocksServices(IStockRepository stockRepository, ILogger<StocksResponse> logger, IMapper mapper)
        {
            _stockRepository = stockRepository;
            _logger = logger;
            _mapper = mapper;

        }
        /// <summary>
        /// Convert a StockProduct To StockResponse
        /// </summary>
        /// <param name="listProductStock"></param>
        /// <returns></returns>
        private static List<StocksResponse> ToStockResponse(IEnumerable<Entities.StockProduct> listProductStock)
        {
            var group = listProductStock.GroupBy(
                 p => p.Product,
                 p => p.Amoun,
                 (key, g) => new { Product = key, Amoun = g.ToList().Sum() });
            var stockResponseList = new List<StocksResponse>();
            group.ToList().ForEach(p => stockResponseList.Add(new StocksResponse() { ProductName = p.Product.Name, Count = p.Amoun, ProductId = p.Product.Id, ProductCategory = p.Product.Category.Description }));
            return stockResponseList;
        }

        /// <summary>
        /// return all available products
        /// </summary>
        /// <returns></returns>
        public IEnumerable<StocksResponse> GetAllAvailable()
        {
            var listProductStock = _stockRepository.GetAllAsync().Result;
            List<StocksResponse> stockResponseList = ToStockResponse(listProductStock); 
            return stockResponseList;
        }

        public IEnumerable<StocksResponse> GetAllAvailableByStore(Guid storeId)
        {
            var listProductStock = _stockRepository.GetAllAvailableByStore(storeId).Result;
            List<StocksResponse> stockResponseList = ToStockResponse(listProductStock);
            return stockResponseList;
        }

        public StocksResponse? GetByPrductAndStore(Guid productID, Guid storeId)
        {
            var aProductStock = _stockRepository.GetByStoreAndProduct(productID,storeId).Result;
            return aProductStock == null? null : new StocksResponse() { ProductName= aProductStock.Product.Name, Count = aProductStock.Amoun, ProductId= aProductStock.Product.Id, ProductCategory = aProductStock.Product.Category.Description };
        }
    }
}

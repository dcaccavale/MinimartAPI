using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using Entities;
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
        private IEnumerable<StocksResponse> ToStockResponse(IEnumerable<Entities.StockProduct> listProductStock)
        {
            var group = listProductStock.GroupBy(
                 p => p.Product,
                 p => p.Quantity,
                 (key, g) => new { Product = key, Quantity = g.ToList().Sum() });
            var stockResponseList = new List<StockProduct>();
            group.ToList().ForEach(p => stockResponseList.Add(new StockProduct() { Quantity = p.Quantity, Product = p.Product }));
           
            return _mapper.Map<IEnumerable<StockProduct>, IEnumerable<StocksResponse>>(stockResponseList);
        }

        /// <summary>
        /// Gets all available products
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StocksResponse>?> GetAllAvailable()
        {
            return ToStockResponse(await _stockRepository.GetAllAvailableAsync());
        }

        /// <summary>
        /// Get stock avaliable by Stores 
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StocksResponse>?> GetAllAvailableByStore(Guid storeId)
        {
            var listProductStock = await _stockRepository.GetAllAvailableByStore(storeId);
            return ToStockResponse(listProductStock);
        }
        /// <summary>
        /// Get the stock value by Product and Store
        /// </summary>
        /// <param name="productID"></param>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public async Task<StocksResponse?> GetByPrductAndStore(Guid productID, Guid storeId)
        {
            var aProductStock = await _stockRepository.GetByStoreAndProduct(productID,storeId);
            if (aProductStock == null) return null;
            return  _mapper.Map<StockProduct, StocksResponse>(aProductStock);
        }

       
    }
}

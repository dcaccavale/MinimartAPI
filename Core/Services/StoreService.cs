using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;
using Microsoft.Extensions.Logging;

namespace Core
{
    public class StoreServices : IStoreServices
    {
        private readonly IStoreRepository _storeRepository;
        private readonly ILogger<StoreResponse> _logger;
  
        private readonly IMapper _mapper;

        public StoreServices(IStoreRepository storeRepository, ILogger<StoreResponse> logger, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _logger = logger;
            _mapper = mapper;
        
        }
        public virtual async Task<IEnumerable<StoreResponse>> GetAllAsync()
        {
            _logger.Log(LogLevel.Information, "Esta obteniendo todos las entidades.");
             var result = await _storeRepository.GetAllAsync();
            // var pp = _mapper.Map<StoreResponse>(new Store());
            var pp = _mapper.ConfigurationProvider;
           
             return _mapper.Map<List<StoreResponse>>(result);
              
        }

        public virtual async Task<StoreResponse> GetAsync(Guid Id)
        {
            _logger.Log(LogLevel.Information, "Esta obteniendo todos las entidades.");
            var result = await _storeRepository.GetAsync(Id);
            // var pp = _mapper.Map<StoreResponse>(new Store());
            var pp = _mapper.ConfigurationProvider;

            return _mapper.Map<StoreResponse>(result);

        }

    }
}

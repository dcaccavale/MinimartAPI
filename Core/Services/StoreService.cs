using AutoMapper;
using Core.Infrastructure;
using Core.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Entities;
using Microsoft.Extensions.Logging;

namespace Core.Services
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
        public async Task<IEnumerable<StoreResponse>> GetAllAsync()
        {
            _logger.Log(LogLevel.Information, "Esta obteniendo todos las entidades.");
             var result = await _storeRepository.GetAllAsync();
            // var pp = _mapper.Map<StoreResponse>(new Store());
            var pp = _mapper.ConfigurationProvider;
           
             return _mapper.Map<List<StoreResponse>>(result);
              
        }

        public  IEnumerable<StoreResponse> GetAllAvailable(DayOfWeek dayOfWeek, TimeSpan  time)
        {
            _logger.Log(LogLevel.Information, "");
            var listStores =  _storeRepository.GetAllAvailable(dayOfWeek, time);
            ICollection<StoreResponse> result = new List<StoreResponse>();
            listStores.ToList().ForEach(s=> result.Add(new StoreResponse() {Name= s.Name })
                );
            return  result.AsEnumerable<StoreResponse>();
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

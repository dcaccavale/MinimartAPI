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

        public StoreServices(IStoreRepository storeRepository,IMapper mapper, ILogger<StoreResponse> logger)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
            _logger = logger;
        }
        /// <summary>
        /// Get all Store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<StoreResponse>> GetAllAsync()
        {
            _logger.Log(LogLevel.Information, "Gets Stores");
             var result = await _storeRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResponse>>(result);

        }

        /// <summary>
        /// Gets store available in day of week and time
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public async Task<IEnumerable<StoreResponse>> GetAllAvailable(DayOfWeek dayOfWeek, TimeSpan  time)
        {
            _logger.Log(LogLevel.Information, "");
            var listStores = await _storeRepository.GetAllWhitDailyTimeRange();
            ICollection<Store> result = new List<Store>();
            foreach (var store in listStores)
            {
                if (store.IsOpen(time, dayOfWeek))
                    result.Add(store);
            };
            return _mapper.Map<IEnumerable<Store>, IEnumerable<StoreResponse>>(result);
        }


        /// <summary>
        /// Gets one by Id store
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<StoreResponse> GetAsync(Guid Id)
        {
            _logger.Log(LogLevel.Information, "Get Store by Id");
            var result = await _storeRepository.GetAsync(Id);
            return _mapper.Map<Store,StoreResponse>(result);
        }

    }
}

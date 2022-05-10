using Core.Infrastructure;
using Core.Interfaces;
using Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minimart_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        private readonly IStoreServices _storeServices;

        // GET: api/<StoresController>
        public StoresController(IStoreServices storeServices)
        {
            _storeServices = storeServices;
        }

        /// <summary>
        /// Gets all stores 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public Task<IEnumerable<StoreResponse>> Get()
        {
            
          return _storeServices.GetAllAsync();
        }
        /// <summary>
        ///  Gets store available in day of week and time
        /// </summary>
        /// <param name="dayOfWeek"></param>
        /// <param name="hour"></param>
        /// <param name="minutes"></param>
        /// <returns></returns>
        [HttpGet("/available/{dayOfWeek,hour,minute}")]
        public Task<IEnumerable<StoreResponse>> GetAllAvailable(string dayOfWeek, byte hour, byte minutes)
        {
            object value;
            Enum.TryParse(typeof(DayOfWeek), dayOfWeek,out value);
            if (value == null)
            { 
                this.Response.StatusCode = 400;
          
            }
            return _storeServices.GetAllAvailable((DayOfWeek)value, new TimeSpan( hour, minutes,0)); 
        }


      
        /// <summary>
        /// Gets store by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/<StoresController>/5
        [HttpGet("{id}")]
        public Task<StoreResponse> Get(Guid id)
        {
            return _storeServices.GetAsync(id);
        }

     
    }
}

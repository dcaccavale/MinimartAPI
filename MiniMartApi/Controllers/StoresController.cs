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
        [HttpGet]
        public Task<IEnumerable<StoreResponse>> Get()
        {
          return _storeServices.GetAllAsync();
        }

        // GET api/<StoresController>/5
        [HttpGet("{id}")]
        public Task<StoreResponse> Get(Guid id)
        {
            return _storeServices.GetAsync(id);
        }

        // POST api/<StoresController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StoresController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StoresController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

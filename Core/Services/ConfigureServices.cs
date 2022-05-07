using Core.Interfaces;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class ConfigureServices : IConfigureServices
    {
        private readonly IConfigureRepository _configureRepository;
        private readonly ILogger<object> _logger;

        public ConfigureServices(IConfigureRepository confRepository, ILogger<object> logger)
        {
            _configureRepository = confRepository;
            _logger = logger;

        }
        public void initModel()
        {
            _configureRepository.initModel();   
        }
    }
}

using DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class ConfigureRepository : GenericRepository, IConfigureRepository
    {
        public ConfigureRepository(MinimarketDataContext dataContext) : base(dataContext)
        {
        }
        /// <summary>
        ///Initialize the database
        /// </summary>
        public void initModel()
        {
            DbInitializer.InitDataBase(_dataContext);
        }
    }
}

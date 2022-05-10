using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Discount
{
    public  class GenericDiscount :Entity 
    {
        /// <summary>
        /// maximum limit to apply discount, if the value 0 indicates unlimited
        /// </summary>
        public int Limit { get; set; }
    }
}

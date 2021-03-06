using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    /// <summary>
    /// Class to register a  date  range
    /// </summary>
    public class RangeDate : Entity
    {
        public  DateTime DateFrom { get; set; }
        public  DateTime DateTo { get; set; }

        public RangeDate()
        {

        }
        public RangeDate(DateTime dateFrom, DateTime dateTo)
        {
            if( dateTo < dateFrom)
                    throw new ArgumentOutOfRangeException();
            DateTo = dateTo;
            DateFrom = dateFrom;
        }
        /// <summary>
        /// Use this method to tell if a date is between a date range
        /// </summary>
        /// <param name="dateNow"></param>
        /// <returns></returns>
        public bool DateInRange(DateTime dateNow)
        { 

                return DateFrom <= dateNow && DateTo >= dateNow;
        }

    }
}

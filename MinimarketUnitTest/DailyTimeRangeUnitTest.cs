using Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimarketUnitTest
{
    internal class DailyTimeRangeUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// invalid from and to date range constructor
        /// </summary>
        ///
        [Test]
        public void CtorFailureDailyTimeRange_Throws()
        {
            DailyTimeRange rangeDate = new();
            Assert.Throws<ArgumentOutOfRangeException>(() => new DailyTimeRange(new DateTime().AddHours(8), new DateTime().AddHours(4), DayOfWeek.Friday));

        }

      

        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_IntervalIn()
        {
            DateTime dateTime = new DateTime().AddHours(9);

            DateTime auxDatetime = new DateTime().AddHours(8);
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek = dateTime.DayOfWeek.ToString(),
                HourFrom = auxDatetime,
                HourTo = auxDatetime.AddHours(12)
            };
            Assert.True(dailyTimeRange.HourInRange(dateTime));
        }
        /// <summary>
        /// 
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_WhioutInterval()
        {
            DateTime dateTime = new DateTime().AddHours(6);//6:00

            DateTime auxDatetime = new DateTime().AddHours(8); //8:00
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek =dateTime.DayOfWeek.ToString(),
                HourFrom = auxDatetime,
                HourTo = auxDatetime.AddHours(12) //20:00
            };
            Assert.False(dailyTimeRange.HourInRange(dateTime));


        }

        /// <summary>
        /// Diferent day of week ,  0001/1/1  "Monday"
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_WhioutDayofWeek()
        {
            DateTime dateTime = new DateTime().AddHours(10);//10:00

            DateTime auxDatetime = new DateTime().AddHours(8); //8:00
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek = DayOfWeek.Wednesday.ToString(),
                HourFrom = auxDatetime,
                HourTo = auxDatetime.AddHours(12) //20:00
            };
            Assert.False(dailyTimeRange.HourInRange(dateTime));


        }
    }
}

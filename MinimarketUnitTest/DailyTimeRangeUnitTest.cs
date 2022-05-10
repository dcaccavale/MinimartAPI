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
            Assert.Throws<ArgumentOutOfRangeException>(() => new DailyTimeRange(new TimeSpan(8,0,0), new TimeSpan(4,0,0), DayOfWeek.Friday));

        }



        /// <summary>
        /// Valid from and to date range 
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_IntervalIn()
        {
            TimeSpan time = new TimeSpan(9, 0, 0);
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek = DayOfWeek.Monday.ToString(),
                HourFrom = new TimeSpan(8, 0, 0),
                HourTo = new TimeSpan(22,0,0)
            };
            Assert.True(dailyTimeRange.HourInRange(DayOfWeek.Monday, time));
        }
        /// <summary>
        /// invalid from and to date range, out of houer 
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_WhioutInterval()
        {
            TimeSpan time = new TimeSpan(22, 30, 0);
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek = DayOfWeek.Monday.ToString(),
                HourFrom = new TimeSpan(8, 0, 0),
                HourTo = new TimeSpan(22, 0, 0)
            };
            Assert.False(dailyTimeRange.HourInRange(DayOfWeek.Monday, time));

        }

        /// <summary>
        /// Invalid day of week   
        /// </summary>
        ///
        [Test]
        public void DailyTimeRange_WhioutDayofWeek()
        {
            TimeSpan time = new TimeSpan(19, 30, 0);
            DailyTimeRange dailyTimeRange = new DailyTimeRange()
            {
                DayOfWeek = DayOfWeek.Monday.ToString(),
                HourFrom = new TimeSpan(8, 0, 0),
                HourTo = new TimeSpan(22, 0, 0)
            };
            Assert.False(dailyTimeRange.HourInRange(DayOfWeek.Tuesday, time));



        }
    }
}

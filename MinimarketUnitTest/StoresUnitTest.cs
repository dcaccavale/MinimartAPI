using Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinimarketUnitTest
{
    public class StoresUnitTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// the store is open at the set time
        /// </summary>
        ///
        [Test]
        public void StoreIsOpenTest()
        {
            Store store = new Store()
            {
                DailyTimeRange = new List<DailyTimeRange>() {
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new  TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom =new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Thursday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Friday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Saturday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) }

            }
            };
            /// 10:00 "Monday" is open
            Assert.True(store.IsOpen(new TimeSpan(10, 0, 0), DayOfWeek.Monday));
        }
        /// <summary>
        /// the store is closed at the set time
        /// </summary>
        ///
        [Test]
        public void StoreIsCloseInHoursTest()
        {
            Store store = new Store()
            {
                DailyTimeRange = new List<DailyTimeRange>() {
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) }

            }
            };
                /// 20:30 "Monday" is open
                Assert.False(store.IsOpen(new TimeSpan(20, 30, 0), DayOfWeek.Monday));
            }

        /// <summary>
        /// Store don´t open this day
        /// </summary>
        ///
        [Test]
        public void StoreIsCloseDayTest()
        {
            Store store = new Store()
            {
                DailyTimeRange = new List<DailyTimeRange>() {
                new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
                new DailyTimeRange(){ DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },
                new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new TimeSpan(8,0,0), HourTo = new TimeSpan(20,30,0) },

            }
            };
                /// 18:30 "Friday" is closed
                Assert.False(store.IsOpen(new TimeSpan(18, 30, 0), DayOfWeek.Friday));

            }

        }
}

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
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) }

            }};
            /// 0001/1/1 10:00 "Monday" is open
            Assert.True(store.IsOpen(new DateTime().AddHours(10)));
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
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Monday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) }

            }
            };
            /// 0001/1/1  "Monday"
            Assert.False(store.IsOpen(new DateTime().AddHours(23)));
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
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Sunday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Tuesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) },
            new DailyTimeRange(){ DayOfWeek = DayOfWeek.Wednesday.ToString(), HourFrom = new DateTime().AddHours(8), HourTo = new DateTime().AddHours(20) }

            }
            };
            /// 0001/1/1  "Monday"
            Assert.False(store.IsOpen(new DateTime().AddHours(10)));
        }

    }
}

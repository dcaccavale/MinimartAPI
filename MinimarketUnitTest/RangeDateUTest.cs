using Entities;
using NUnit.Framework;
using System;
namespace MinimarketUnitTest
{
    public class RangeDateUTest
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
        public void CtorFailureRangeDateObject_Throws()
        {
            RangeDate rangeDate = new ();
            Assert.Throws<ArgumentOutOfRangeException>( ()=>  new RangeDate(DateTime.Now, DateTime.Now.AddMonths(-2)));
          
        }

        /// <summary>
        /// Valid from and to date range constructor
        /// </summary>
        ///
        [Test]
        public void CtorRangeDateObject_Throws()
        {
            
            Assert.DoesNotThrow(() => new RangeDate(DateTime.Now, DateTime.Now.AddMonths(2)));

        }
        /// <summary>
        /// Valid from and to date range
        /// </summary>
        ///
        [Test]
        public void ValidateDateinRange_DateInRange()
        {
            var rangeDate = new RangeDate(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(2));
            Assert.True(rangeDate.DateInRange(DateTime.Now));


        }
        /// <summary>
        /// unvalid from and to date range
        /// </summary>
        ///
        [Test]
        public void unvalidDateinRange_DateInRange()
        {
            var rangeDate = new RangeDate(DateTime.Now.AddMonths(-2), DateTime.Now.AddMonths(2));
            Assert.False(rangeDate.DateInRange(DateTime.Now.AddMonths(4)));
            Assert.False(rangeDate.DateInRange(DateTime.Now.AddMonths(-4)));


        }
    }
}
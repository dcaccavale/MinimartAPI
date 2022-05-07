using Entities;
using Entities.Discount;
using NUnit.Framework;
using System;

namespace MinimarketUnitTest
{
    public  class DiscountsUTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /// <summary>
        /// Calculate discount , limit = 0 applies without limits,  product priceUnit 2  product quantity 1  discount percentage 10% = total Discount 0.2 
        /// </summary>
        ///
        [Test]
        public void PercentageDiscountCalculateWithoutLimitTest()
        {
            PercentageDiscount percentageDiscount = new() { Percentage = 10 , Limit = 0 };
            Assert.AreEqual(percentageDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 2, Quantity = 1 }), 0.2);

        }

        /// <summary>
        /// Calculate discount , limit = 1 applies whit limit ,  product priceUnit 2  product quantity 3  discount percentage 10% = total Discount 0.2 
        /// </summary>
        ///
        [Test]
        public void PercentageDiscountCalculateWithLimitTest()
        {
            PercentageDiscount percentageDiscount = new() { Percentage = 10, Limit = 1 };
            Assert.AreEqual(percentageDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 2, Quantity = 3 }), 0.2);

        }

        /// <summary>
        /// Calculate discount , limit = 0 applies whitout limit ,  product priceUnit 1  product quantity 4  discount percentage 50% => total Discount 1 
        /// </summary>
        ///
        [Test]
        public void PercentageSecundDiscountCalculateWithOutLimitTest()
        {
            PercentageSecundDiscount percentageDiscount = new() { Percentage = 50, Limit = 0 };
            Assert.AreEqual(percentageDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 4 }),1);

        }
        /// <summary>
        /// Calculate discount , limit = 2 applies whit limit ,  product priceUnit 1  product quantity 4  discount percentage 50% => total Discount 0.5 
        /// </summary>
        ///
        [Test]
        public void PercentageSecundDiscountCalculateWithLimitTest()
        {
            PercentageSecundDiscount percentageDiscount = new() { Percentage = 50, Limit = 2 };
            Assert.AreEqual(percentageDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 4 }), 0.5);

        }
        /// <summary>
        /// Calculate discount , limit = 0 applies whitout limit ,  product priceUnit 1  product quantity 1  discount percentage in secound product 50% => total Discount 0 
        /// </summary>
        ///
        [Test]
        public void PercentageSecundDiscountNotApplyTest()
        {
            PercentageSecundDiscount percentageDiscount = new() { Percentage = 50, Limit = 0 };
            Assert.AreEqual(percentageDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 1 }), 0);

        }


        /// <summary>
        /// Calculate Pay to Take discount ,  product priceUnit 1  product quantity 7  discount  Pay 2 take 3  => total Discount  2 product price 1 
        /// </summary>
        ///
        [Test]
        public void PayTakeDiscountTest()
        {
            PayTakeDiscount payTakeDiscount = new() { PayCount = 2 , TakeCount = 3 };
            Assert.AreEqual(payTakeDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 7 }), 2);

        }

        /// <summary>
        /// Calculate Pay to Take discount , limit = 0 applies whitout limit ,  product priceUnit 1  product quantity 4  discount  Pay 2 take 3  => total Discount  1 product price 1 
        /// </summary>
        ///
        [Test]
        public void PayTakeDiscountApplyTest()
        {
            PayTakeDiscount payTakeDiscount = new() { PayCount = 3, TakeCount = 4 };
            Assert.AreEqual(payTakeDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 4 }), 1);

        }

        /// <summary>
        /// Calculate Pay to Take discount not aplly ,the quantity to pay is equal than the amount of product
        /// </summary>
        ///
        [Test]
        public void PayTakeDiscountNNTest()
        {
            PayTakeDiscount payTakeDiscount = new() { PayCount = 2, TakeCount = 3 };
            
            Assert.AreEqual(payTakeDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 2 }), 0);

        }

        /// <summary>
        /// Calculate Pay to Take discount Not Apply  ,  the quantity to pay is less than the amount of product
        /// </summary>
        ///
        [Test]
        public void PayTakeDiscountNotApplyTest()
        {
            PayTakeDiscount payTakeDiscount = new() { PayCount = 3, TakeCount = 4 };
            Assert.AreEqual(payTakeDiscount.CalculateDiscount(new ItemProduct() { PriceUnit = 1, Quantity = 2 }), 0);

        }

    }
}

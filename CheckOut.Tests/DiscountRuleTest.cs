using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckOut.Rules;
using CheckOut.Entities;
using System.Collections.Generic;
using CheckOut.Tests.Builders;

namespace CheckOut.Tests
{
    [TestClass]
    public class DiscountRuleTest
    {
        [TestMethod]
        public void TestSingleSalePriceDiscount()
        {
            var promotions = new List<ProductDiscount>();
            promotions.Add(new ProductDiscountBuilder().Build());
            var cartItem = new CartItemBuilder().Build();
            var rule = new SalePriceRule(promotions);

            rule.CalculateDiscount(cartItem);

            Assert.AreEqual(1.0m, cartItem.Discount);
        }
        [TestMethod]
        public void TestMultipleSalePriceDiscount()
        {
            var promotions = new List<ProductDiscount>();
            promotions.Add(new ProductDiscountBuilder().Build());
            promotions.Add(new ProductDiscountBuilder().WithDiscountPrice(0.75m).Build());
            var cartItem = new CartItemBuilder().Build();
            var rule = new SalePriceRule(promotions);

            rule.CalculateDiscount(cartItem);

            //Should return the largest discount off the regular price
            Assert.AreEqual(1.25m, cartItem.Discount);
        }
    }
}

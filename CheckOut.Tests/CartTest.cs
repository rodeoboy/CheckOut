using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckOut.Entities;
using CheckOut.Tests.Builders;
using System.Collections.Generic;

namespace CheckOut.Tests
{
    [TestClass]
    public class CartTest
    {
        [TestMethod]
        public void TestAddingSingleProducts()
        {
            var promotions = new List<ProductDiscount>();
            var cart = new Cart(promotions);
            cart.AddItem(new ProductBuilder().Build());

            Assert.AreEqual(1, cart.Items.Count);
            Assert.AreEqual(1, cart.GetItemByProductName("Apple").Quantity);
        }

        [TestMethod]
        public void TestAddingMultipleProducts()
        {
            var promotions = new List<ProductDiscount>();
            var cart = new Cart(promotions);
            cart.AddItem(new ProductBuilder().Build());
            cart.AddItem(new ProductBuilder().WithProduct("Oragne").WithId(2).Build());
            cart.AddItem(new ProductBuilder().WithProduct("Banana").WithId(3).Build());

            Assert.AreEqual(3, cart.Items.Count);
            Assert.AreEqual(1, cart.GetItemByProductName("Apple").Quantity);
            Assert.AreEqual(1, cart.GetItemByProductName("Oragne").Quantity);
            Assert.AreEqual(1, cart.GetItemByProductName("Banana").Quantity);
        }

        [TestMethod]
        public void TestAddingMultipleOfSameProducts()
        {
            var promotions = new List<ProductDiscount>();
            var cart = new Cart(promotions);
            cart.AddItem(new ProductBuilder().Build());
            cart.AddItem(new ProductBuilder().WithProduct("Oragne").WithId(2).Build());
            cart.AddItem(new ProductBuilder().WithProduct("Banana").WithId(3).Build());
            cart.AddItem(new ProductBuilder().Build());
            cart.AddItem(new ProductBuilder().WithProduct("Oragne").WithId(2).Build());
            cart.AddItem(new ProductBuilder().WithProduct("Banana").WithId(3).Build());
            cart.AddItem(new ProductBuilder().Build());

            Assert.AreEqual(3, cart.Items.Count);
        }
    }
}

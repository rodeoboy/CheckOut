using CheckOut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Tests.Builders
{
    class CartItemBuilder
    {
        CartItem item;
        public CartItemBuilder()
        {
            item = new CartItem()
            {
                ProductId = 1,
                ProductName = "Apples",
                RegularPrice = 2.0m,
                Quantity = 1
            };
        }
        public CartItem Build()
        {
            return item;
        }

        public CartItemBuilder WithQuantity(int count)
        {
            item.Quantity = count;
            return this;
        }
        public CartItemBuilder WithQuantityIncrement()
        {
            item.Quantity += 1;
            return this;
        }

        public CartItemBuilder WithProduct(string name)
        {
            item.ProductName = name;
            return this;
        }

        public CartItemBuilder WithPrice(decimal price)
        {
            item.RegularPrice = price;
            return this;
        }

        public CartItemBuilder WithProductId(int id)
        {
            item.ProductId = id;
            return this;
        }
    }
}


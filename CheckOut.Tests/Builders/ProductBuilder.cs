using CheckOut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Tests.Builders
{
    public class ProductBuilder
    {
        private Product item;
        public ProductBuilder()
        {
            item = new Product()
            {
                Id = 1,
                Name = "Apple",
                Price = 2.0m,
            };
        }
        public Product Build()
        {
            return item;
        }
        

        public ProductBuilder WithProduct(string name)
        {
            item.Name = name;
            return this;
        }

        public ProductBuilder WithPrice(decimal price)
        {
            item.Price = price;
            return this;
        }

        public ProductBuilder WithId(int id)
        {
            item.Id = id;
            return this;
        }
    }
}

using CheckOut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Tests.Builders
{
    class ProductDiscountBuilder
    {
        private ProductDiscount item;

        public ProductDiscountBuilder()
        {
            item = new ProductDiscount()
            {
                Id = 1,
                Type = DiscountType.SalePrice,
                DiscountPrice = 1.00m,
                ExpiryDate = DateTime.Now.AddDays(1),
                ProductId = 1
            };
        }

        public ProductDiscount Build()
        {
            return item;
        }

        public ProductDiscountBuilder WithExpiryDate(DateTime date)
        {
            item.ExpiryDate = date;
            return this;
        }

        public ProductDiscountBuilder WithType(DiscountType type)
        {
            item.Type = type;
            return this;
        }

        public ProductDiscountBuilder WithDiscountPrice(decimal price)
        {
            item.DiscountPrice = price;
            return this;
        }

        public ProductDiscountBuilder WithProductId(int id)
        {
            item.ProductId = id;
            return this;
        }

        public ProductDiscountBuilder WithId(int id)
        {
            item.Id = id;
            return this;
        }
    }
}

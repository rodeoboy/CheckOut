using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckOut.Entities;

namespace CheckOut.Rules
{
    public class SalePriceRule : IDiscountRule
    {
        IEnumerable<ProductDiscount> _discounts;
        public SalePriceRule(IEnumerable<ProductDiscount> discounts)
        {
            _discounts = discounts.Where(d => d.Type == DiscountType.SalePrice && DateTime.Compare(d.ExpiryDate, DateTime.Now.Date) > 0);
        }
        public void CalculateDiscount(CartItem item)
        {
            decimal discount = 0.0m;
            var discountsForItem = _discounts.Where(d => d.ProductId == item.ProductId);
            // Always apply the lowest price
            if (discountsForItem.Count() > 0)
            {
                discount = item.RegularPrice - discountsForItem.Min(d => d.DiscountPrice);
                if (discount > item.Discount)
                    item.Discount = discount;
            }
        }
    }
}

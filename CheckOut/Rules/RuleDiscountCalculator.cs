using CheckOut.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Rules
{
    public class RuleDiscountCalculator : IDiscountCalculator
    {
        List<IDiscountRule> rules = new List<IDiscountRule>();
        public RuleDiscountCalculator(IEnumerable<ProductDiscount> promotions)
        {
            //Add all the relivant rules for the product
            rules.Add(new SalePriceRule(promotions.Where(p => p.Type == DiscountType.SalePrice)));
        }

        public void CalculateDiscountPrice(CartItem item)
        {
            foreach(var rule in rules)
            {
                rule.CalculateDiscount(item);
            }
        }
    }

    public interface IDiscountCalculator 
    {
        void CalculateDiscountPrice(CartItem item);
    }

    public interface IDiscountRule
    {
        void CalculateDiscount(CartItem item);
    }
}

using CheckOut.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Entities
{
    public class Cart : IHaveItems
    {
        private static Cart instance;
        private List<CartItem> items;
        private RuleDiscountCalculator rules;
        private static readonly object padlock = new object();

        public int Id { get; set; }        
        public virtual IReadOnlyList<CartItem> Items
        {
            get { return items; }
        }

        public Cart(List<ProductDiscount> promotions)
        {
            rules = new RuleDiscountCalculator(promotions);
            items = new List<CartItem>();
        }
        public void AddItem(Product product)
        {
            if (Items.Any(i => i.ProductId == product.Id))
            {
                Items.Where(i => i.ProductId == product.Id).FirstOrDefault().Quantity += 1;
            }
            else
            { 
                var item =new CartItem()
                {
                    ProductId = product.Id,
                    ProductName = product.Name,
                    Quantity = 1,
                    Discount = 0.0m,
                    RegularPrice = product.Price
                };
                items.Add(item);
            }
            if (rules != null) rules.CalculateDiscountPrice(Items.Where(i => i.ProductId == product.Id).FirstOrDefault());
        }
        public IReadOnlyCart GetItemByProductName(string name)
        {
            return items.Find(i => i.ProductName.ToUpper() == name.ToUpper());
        }
    }
    
}

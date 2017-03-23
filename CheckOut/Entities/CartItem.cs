using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Entities
{
    public class CartItem : IReadOnlyCart
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal RegularPrice { get; set; }
        public decimal Discount { get; set; }
        public decimal Cost
        {
            get { return RegularPrice - Discount; }
        }
        public decimal Total
        {
            get { return Cost * Quantity; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Entities
{
    public class ProductDiscount
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public DiscountType Type { get; set; }

        public decimal DiscountPrice { get; set; }

        public DateTime ExpiryDate { get; set; }
    }

    public enum DiscountType
    {
        None,
        SalePrice,
        GroupPrice,
        AdditionalDiscount
    }
}

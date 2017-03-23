using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Index(IsUnique = true)]
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

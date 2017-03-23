using CheckOut.Entities;
using CheckOut.Rules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckOut.Service
{
    class CheckOutService
    {
        List<Product> products;
        List<ProductDiscount> promotions;
        Cart cart;
        public CheckOutService()
        {
            products = new List<Product>();
            promotions = new List<ProductDiscount>();
            LoadProductCatalog(@"..\..\..\Products.txt");
            LoadPromotions(@"..\..\..\ProductPromotions.txt");
            cart = new Cart(promotions);
        }

        public void LoadProductCatalog(string path)
        {
            if(string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("File path is required");
            }

            using (StreamReader sr = File.OpenText(@path))
            {
                int id = 1;
                string row = string.Empty;

                while ((row = sr.ReadLine()) != null)
                {
                    var col = row.Split(',');
                    var product = new Product()
                    {
                        Id = id,
                        Name = col[0],
                        Price = Convert.ToDecimal(col[1]),
                    };
                    products.Add(product);
                    id++;
                }
            }
        }

        public void LoadPromotions(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("File path is required");
            }

            using (StreamReader sr = File.OpenText(@path))
            {
                int id = 1;
                string row = string.Empty;

                if(promotions.Count > 0)
                    id = promotions.Max(p => p.Id);

                while ((row = sr.ReadLine()) != null)
                {
                    var col = row.Split(',');
                    var type = (DiscountType)Enum.Parse(typeof(DiscountType), col[0]);
                    int productId = 0;
                    DateTime expiry = DateTime.Now;
                    
                    if (DateTime.TryParse(col[2], out expiry) && int.TryParse(col[3], out productId))
                    {
                        var promotion = new ProductDiscount()
                        {
                            Id = id,
                            Type = type,
                            DiscountPrice = Convert.ToDecimal(col[1]),
                            ExpiryDate = expiry,
                            ProductId = (int)productId
                        };
                        promotions.Add(promotion);
                        id++;
                    }
                }
            }
        }

        public void CheckoutItems(string path)
        {   
            cart = new Cart(promotions);
            using (StreamReader sr = File.OpenText(@path))
            {
                string itemName = string.Empty;

                while ((itemName = sr.ReadLine()) != null)
                {
                    if (products.Any(p => p.Name.ToUpper() == itemName.ToUpper()))
                    {
                        cart.AddItem(products.FirstOrDefault(p => p.Name.ToUpper() == itemName.ToUpper()));
                    }
                }
            }   
        }

        public IHaveItems GetCart()
        {
            return cart;
        }
    }
}

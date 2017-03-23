using CheckOut.Entities;
using CheckOut.Service;
using System;
using System.IO;

namespace CheckOut
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            string path = string.Empty;

            try
            {
                CheckOutService service = new CheckOutService();
                do
                {
                    input = DisplayMenu();

                    switch (input)
                    {
                        case 1:
                            path = PromptForFile();
                            if (ValidatePath(path))
                            {
                                service.CheckoutItems(path);
                                PrintReciept(service.GetCart());
                            }
                            break;
                        case 2:
                            path = PromptForFile();
                            if (ValidatePath(path)) service.LoadProductCatalog(path);
                            break;
                        case 3:
                            path = PromptForFile();
                            if (ValidatePath(path)) service.LoadPromotions(path);
                            break;
                    }
                } while (input != 4);
            }
            catch(Exception ex)
            {
                //should log the exception for later use
                Console.WriteLine("Sorry, there was an error. Please try again.");
            }
        }
        static void PrintReciept(IHaveItems cart)
        {
            string currencyFormat = "C";
            decimal grandTotal = 0.0m;
            string lineFormat = "{0,7} {1,20} {2,20} {3,10} {4,20} {5,10}";
            Console.WriteLine();
            Console.WriteLine("Receipt");
            Console.WriteLine("{0,7} {1,20} {2,20} {3,10} {4,20} {5,10:N1}",
                                "Quantity",
                                "Product Name",
                                "Discount",
                                "Type",
                                "Regular Price",
                                "Cost");
            foreach (var item in cart.Items)
            {
                grandTotal += item.Total;
                Console.WriteLine(lineFormat, item.Quantity, item.ProductName, item.Discount.ToString(currencyFormat), item.DiscountType == DiscountType.None? string.Empty: item.DiscountType.ToString(), item.RegularPrice.ToString(currencyFormat), item.Total.ToString(currencyFormat));
            }
            Console.WriteLine("{0,81} {1,10}", "Grand Total:", grandTotal.ToString(currencyFormat));
        }

        static string PromptForFile()
        {
            Console.WriteLine();
            Console.WriteLine("Enter file path to load.");
            string path = Console.ReadLine();
            
            return path;
        }

        static bool ValidatePath(string path)
        {
            if (File.Exists(path))
                return true; 
            else
            {
                Console.WriteLine("File '" + path + "' can not be found.");
                return false;
            }
        }

        static public int DisplayMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Check Out Menu");
            Console.WriteLine();
            Console.WriteLine("1. Check out items");
            Console.WriteLine("2. Add products");
            Console.WriteLine("3. Add promotions");
            Console.WriteLine("4. Exit");
            var result = Console.ReadKey(false);
            return Convert.ToInt32(result.KeyChar.ToString());
        }
    }
}

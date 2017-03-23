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
                        if(ValidatePath(path)) service.LoadPromotions(path);
                        break;
                }
            } while (input != 4);
        }
        static void PrintReciept(IHaveItems cart)
        {
            decimal grandTotal = 0.0m;
            string lineFormat = "{0} {1} {2}";
            Console.WriteLine();
            Console.WriteLine("Receipt");
            Console.WriteLine();
            Console.WriteLine("Receipt");
            foreach (var item in cart.Items)
            {
                grandTotal += item.Total;
                Console.WriteLine(string.Format(lineFormat, item.Quantity, item.ProductName, item.Total));
            }
            Console.WriteLine("Grand Total: " + grandTotal);
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

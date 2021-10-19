using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class CreatingNewProduct
    {
        public Product AddingNewProduct(string category)
        {
            try
            {


                Console.WriteLine("Enter New Product Name");
                string newprodname = Console.ReadLine();
                Console.WriteLine("Enter ID of new Product");
                string newprodID = Console.ReadLine();
                Console.WriteLine("Enter New Product Stock Quantity");
                int stock = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter Price of New Product");
                double price = double.Parse(Console.ReadLine());
                Product temp = new Product(newprodID, newprodname, stock, price, category);
                return temp;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}

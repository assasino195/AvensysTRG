using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class GenerateSalesReport
    {
        public void generatesalesreport(Dictionary<string,Customer> custDict)
        {
            Dictionary<string, Product> countingdictionary = new Dictionary<string, Product>();

            double total = 0;
            foreach (var d in custDict)
            {
                foreach (var a in d.Value.PurchaseHistory)
                {
                    if (countingdictionary.ContainsKey(a.productID))
                    {
                        countingdictionary[a.productID].productCount += a.productCount;
                    }
                    else
                    {
                        countingdictionary.Add(a.productID, a);
                    }
                    Console.WriteLine($"Product ID:{a.productID}\t{a.productName} quantity {a.productCount} at a price of {a.productPrice}");
                    total += a.productCount * a.productPrice;
                }
            }
            Console.WriteLine();
            foreach (var d in countingdictionary)
            {
                Console.WriteLine($"ID: {d.Key}\t{d.Value.productName}\twas sold {d.Value.productCount}\ttimes at {d.Value.productPrice}");
            }
            Console.WriteLine("Total Sales: " + total);
            Console.WriteLine("Total GST Taxed: " + total * 0.07);
        }
    }
}

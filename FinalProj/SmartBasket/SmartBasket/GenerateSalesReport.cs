using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class GenerateSalesReport
    {
        public List<string> generatesalesreport(Dictionary<string,Customer> custDict)
        {
            Dictionary<string, Product> countingdictionary = new Dictionary<string, Product>();
            List<string> temp = new List<string>();
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
                    // Console.WriteLine($"Product ID:{a.productID}\t{a.productName} quantity {a.productCount} at a price of {a.productPrice}");
                    //temp.Add($"Product ID:{a.productID}\t{a.productName} quantity {a.productCount} at a price of {a.productPrice}");
                    total += a.productCount * a.productPrice;
                }
            }
            //Console.WriteLine();
            //countingdictionary.OrderByDescending
            
            foreach (var d in countingdictionary)
            {
                temp.Add($"ID: {d.Key}\t{d.Value.productName}\twas sold {d.Value.productCount}\ttimes at {d.Value.productPrice}");
            }
            temp.Add("Total Sales: " + total);
            temp.Add("Total GST Taxed: " + total * 0.07);
            return temp;
        }
    }
}

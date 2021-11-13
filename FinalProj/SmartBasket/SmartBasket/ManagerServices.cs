using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class ManagerServices
    {
        //public Product AddingNewProduct(string newprodID, string newprodName, int stock, double price, string category)
        //{
        //    //Product temp = new Product(newprodID, newprodName, stock, price, category);
        //    //return temp;
        //}

        //public Customer createcustomer(string idinput, string nameinput, string email, string phoneno)
        //{


        //    if (IsValidEmail(email))
        //    {

        //        if (isvalidphoneno(phoneno))
        //        {
        //            //custDict.Add(idinput,
        //           // Customer temp = new Customer(idinput, nameinput, email, phoneno, "Member");
        //            Console.WriteLine("Welcome to Super Market!");
        //            //return temp;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        return null;
        //    }
        //}
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public bool isvalidphoneno(string phoneno)
        {
            int count = 0;
            foreach (char a in phoneno)
            {
                if (count == 0)
                {
                    if (a == '8' || a == '9')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                count++;
            }
            if (count == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public List<string> generatesalesreport(Dictionary<string, Customer> custDict)
        {
            Dictionary<string, Product> countingdictionary = new Dictionary<string, Product>();
            List<string> temp = new List<string>();
            double total = 0;
            foreach (var d in custDict)
            {
                foreach (var a in d.Value.purchaseHist)
                {
                    if (countingdictionary.ContainsKey(a.productID.ToString()))
                    {
                        countingdictionary[a.productID.ToString()].productCount += a.productCount;
                    }
                    else
                    {
                        countingdictionary.Add(a.productID.ToString(), a);
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
                temp.Add($"ID: {d.Key}\t{d.Value.ProductName}\twas sold {d.Value.productCount}\ttimes at {d.Value.productPrice}");
            }
            temp.Add("Total Sales: " + total);
            temp.Add("Total GST Taxed: " + total * 0.07);
            return temp;
        }
    }
}

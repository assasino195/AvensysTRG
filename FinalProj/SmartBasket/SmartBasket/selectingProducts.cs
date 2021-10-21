using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class selectingProducts
    {
        public List<string> displayproducts(Dictionary<string,Product>prodDict,string category)
        {
            List<string> temp = new List<string>();
            foreach(var prod in prodDict)
            {
                if(prod.Value.productCategory.Equals(category))
                {
                    if (prod.Value.productCount > 0)
                    {
                        string t = $"{prod.Key}. {prod.Value.productName}\t Price is: ${string.Format("{0:N2}", prod.Value.productPrice)}\t " +
                            $"In stock: {prod.Value.productCount}";
                        //Console.WriteLine(t);
                        temp.Add(t);
                    }
                  
                }
            }
            return temp;
        }
        public Product ShopForProduct(Dictionary<string,Product> prodDict,string id,int count)
        {
            //foreach (var prodic in prodDict)
            //{
            //    if (prodic.Value.productCategory.Equals("Vegetables"))
            //    {
            //        if (prodic.Value.productCount > 0)
            //        {
            //            string temp = $"{prodic.Key}. {prodic.Value.productName}\t Price is: ${string.Format("{0:N2}", prodic.Value.productPrice)}\t " +
            //                $"In stock: {prodic.Value.productCount}";
            //            Console.WriteLine(temp);
            //        }
            //    }
            //}
            Product p = prodDict[id];
            p.productCount = count;
            return p;

        }
        //public Product ShopForMeat(Dictionary<string, Product> prodDict)
        //{
        //    foreach (var prodic in prodDict)
        //    {
        //        if (prodic.Value.productCategory.Equals("Meat"))
        //        {
        //            if (prodic.Value.productCount > 0)
        //            {
        //                string temp = $"{prodic.Key}. {prodic.Value.productName}\t Price is: ${string.Format("{0:N2}", prodic.Value.productPrice)}\t " +
        //                    $"In stock: {prodic.Value.productCount}";
        //                Console.WriteLine(temp);
        //            }
        //        }
        //    }
        //    Console.WriteLine("Enter Option of item you wish to buy");
        //    string itemopt = Console.ReadLine();
        //    if (prodDict.ContainsKey(itemopt))
        //    {
        //        Console.WriteLine("Enter Quantity you wish to buy");
        //        try
        //        {
        //            int quant = int.Parse(Console.ReadLine());
        //            if (prodDict[itemopt].productCount < quant)
        //            {
        //                Console.WriteLine("Exceeded the amount of stock we have please lower the count");
        //                return null;
        //            }
        //            else
        //            {
        //                Product tempp = new Product(prodDict, itemopt, quant);


        //                //tempbasket.Add(tempp);
                        
        //                Console.WriteLine("Added to basket");
        //                return tempp;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Enter a valid Number");
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Enter a Valid Option");
        //        return null;
        //    }
        //}
        //public Product ShopForDairy(Dictionary<string, Product> prodDict)
        //{
        //    foreach (var prodic in prodDict)
        //    {
        //        if (prodic.Value.productCategory.Equals("Dairy"))
        //        {
        //            if (prodic.Value.productCount > 0)
        //            {
        //                string temp = $"{prodic.Key}. {prodic.Value.productName}\t Price is: ${string.Format("{0:N2}", prodic.Value.productPrice)}\t " +
        //                    $"In stock: {prodic.Value.productCount}";
        //                Console.WriteLine(temp);
        //            }
        //        }
        //    }
        //    Console.WriteLine("Enter Option of item you wish to buy");
        //    string itemopt = Console.ReadLine();
        //    if (prodDict.ContainsKey(itemopt))
        //    {
        //        Console.WriteLine("Enter Quantity you wish to buy");
        //        try
        //        {
        //            int quant = int.Parse(Console.ReadLine());
        //            if (prodDict[itemopt].productCount < quant)
        //            {
        //                Console.WriteLine("Exceeded the amount of stock we have please lower the count");
        //                return null;
        //            }
        //            else
        //            {
        //                Product tempp = new Product(prodDict, itemopt, quant);


        //                //tempbasket.Add(tempp);
        //                //cusdic.Value.bas.Itembasket.Add(tempp); ;
                       
        //                Console.WriteLine("Added to basket");
        //                return tempp;
        //            }
        //        }
        //        catch (Exception)
        //        {
        //            Console.WriteLine("Enter a valid Number");
        //            return null;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Enter a Valid Option");
        //        return null;
        //    }
        //}
       
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class BasketManager
    {
        public double calculatetotal(List<Product> itembasket)
        {
            double temp = 0;
            foreach (var prod in itembasket)
            {
                temp += prod.productCount * prod.productPrice;
            }
            return temp * 1.07;
        }
        public List<Product> displayHotItems(Dictionary<string, Customer> cusdic)
        {
            List<Product> temp = new List<Product>();
            Dictionary<string, Product> countingdic = new Dictionary<string, Product>();
            foreach (var cus in cusdic)
            {
                foreach (var prodinpurc in cus.Value.PurchaseHistory)
                {
                    if (countingdic.ContainsKey(prodinpurc.productID))
                    {
                        int totalcount = countingdic[prodinpurc.productID].productCount;
                        countingdic[prodinpurc.productID].productCount = totalcount + prodinpurc.productCount;
                    }
                    else
                    {
                        countingdic.Add(prodinpurc.productID, prodinpurc);
                    }
                }
            }
            string item1 = string.Empty;
            string item2 = string.Empty;
            string item3 = string.Empty;
            int item11 = 0;
            int item22 = 0;
            int item33 = 0;
            foreach (var prod in countingdic)
            {
                if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount > item11)
                {
                    item3 = item2;
                    item33 = item22;
                    item2 = item1;
                    item22 = item11;
                    item11 = prod.Value.productCount;
                    item1 = prod.Key;
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount > item22 && prod.Value.productCount < item11)
                {
                    item3 = item2;
                    item33 = item22;

                    item22 = prod.Value.productCount;
                    item2 = prod.Key;
                }
                else if (prod.Value.productCount > item33 && prod.Value.productCount < item22 && prod.Value.productCount < item11)
                {
                    item33 = prod.Value.productCount;
                    item3 = prod.Key;
                }

            }
            temp.Add(countingdic[item1]);
            temp.Add(countingdic[item2]);
            temp.Add(countingdic[item3]);
            //temp.Add($"{countingdic[item1].productID}: {countingdic[item1].productName}\tQuantity Sold:{countingdic[item1].productCount}\tAt: ${countingdic[item1].productPrice}");
            //temp.Add($"{countingdic[item2].productID}: {countingdic[item2].productName}\tQuantity Sold:{countingdic[item2].productCount}\tAt: ${countingdic[item2].productPrice}");
            //temp.Add($"{countingdic[item3].productID}: {countingdic[item3].productName}\tQuantity Sold:{countingdic[item3].productCount}\tAt: ${countingdic[item3].productPrice}");
            //foreach(var prod in countingdic)
            //{

            //    if(prod.Value.productCount>item3 && prod.Value.productCount>item2   &&  prod.Value.productCount>item1)
            //    {

            //        item3 = item2;
            //        item2 = item1;
            //        item1 = prod.Value.productCount;
            //    }
            //    else if(prod.Value.productCount > item3 && prod.Value.productCount > item2 && prod.Value.productCount < item1)
            //    {
            //        item3 = item2;
            //        item2 = prod.Value.productCount;
            //    }
            //}
            return temp;
        }
        public List<string> displayproducts(Dictionary<string, Product> prodDict, string category)
        {
            List<string> temp = new List<string>();
            foreach (var prod in prodDict)
            {
                if (prod.Value.productCategory.Equals(category))
                {
                    if (prod.Value.productCount > 0)
                    {
                        string t = $"{prod.Key}. {prod.Value.ProductName}\t Price is: ${string.Format("{0:N2}", prod.Value.productPrice)}\t " +
                            $"In stock: {prod.Value.productCount}";
                        //Console.WriteLine(t);
                        temp.Add(t);
                    }

                }
            }
            return temp;
        }
        public Product ShopForProduct(Dictionary<string, Product> prodDict, string id, int count)
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
        public Product Removefrombasket(Dictionary<string, Product> prodDict, string id)
        {
            Product p = prodDict[id];
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


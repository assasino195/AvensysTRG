using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class LaunchnExitServices
    {
        public string writingToCustomerTxt(Dictionary<string, Customer> custDict)
        {
            //    FileStream fs1 = new FileStream($"customerdict.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //    StreamWriter sw = new StreamWriter(fs1);

            //    foreach (var d in custDict)
            //    {
            //        sw.WriteLine($"{d.Value.customerID},{d.Value.customerName},{d.Value.customerEmail},{d.Value.customerPhoneNo},{d.Value.role}");
            //    }

            //    sw.Close();
            //    fs1.Close();

            string customerdict = JsonConvert.SerializeObject(custDict);
            File.WriteAllText("customerdict.json", customerdict);
            return "Completed writing to customerdict.txt";
        }
        public string writingToInventoryTxt(Dictionary<string, Product> prodDict)
        {
            //File.Delete(@"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\inventory.txt");
            //FileStream fs2 = new FileStream($"inventory.txt", FileMode.OpenOrCreate, FileAccess.Write);
            //StreamWriter sw2 = new StreamWriter(fs2);

            //foreach (var d in prodDict)
            //{
            //    sw2.WriteLine($"{d.Value.productID},{d.Value.ProductName},{d.Value.productCount},{d.Value.productPrice},{d.Value.productCategory}");
            //}

            //sw2.Close();
            //fs2.Close();
            string Productdic = JsonConvert.SerializeObject(prodDict);
            File.WriteAllText("inventory.json", Productdic);
            return "Completed writing to inventory.txt";
        }
        //public string writingToSmartBasketTxt(Dictionary<string, Customer> custDict)
        //{
        //    //File.Delete(@"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\SmartBasket.txt");
        //    FileStream fs3 = new FileStream($"SmartBasket.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //    StreamWriter sw3 = new StreamWriter(fs3);

        //    //if (!tempbask.isCheckedOut)
        //    //{
        //    //    foreach (var d in tempbask.Itembasket)
        //    //    
        //    //        sw3.WriteLine($"{idinput},{false},{d.productID},{d.productName},{d.productCount},{d.productPrice},{d.productCategory}");
        //    //    }
        //    //}

        //    foreach (var dic in custDict)
        //    {
        //        if (dic.Value.Bas.Itembasket.Count > 0)
        //        {
        //            if (!dic.Value.Bas.isCheckedOut)
        //            {
        //                foreach (var prod in dic.Value.Bas.Itembasket)
        //                {
        //                    sw3.WriteLine($"{dic.Key},{false},{prod.productID},{prod.ProductName},{prod.productCount},{prod.productPrice},{prod.productCategory}");
        //                }
        //            }
        //        }
        //    }
        //    if(fs3.Length==0)
        //    {
        //        sw3.WriteLine(" ");
        //    }
        //    sw3.Close();
        //    fs3.Close();
        //    return "completed writing to smartbasket.txt";
        //}
        //public string WritingToPurchaseHistory(Dictionary<string,Customer> custDict)
        //{
        //    FileStream fs4 = new FileStream($"purchasehistory.txt", FileMode.OpenOrCreate, FileAccess.Write);
        //    StreamWriter sw4 = new StreamWriter(fs4);
        //    //if (tempbask.isCheckedOut)
        //    //{
        //    //    if (custDict[idinput].PurchaseHistory.Count > 0)
        //    //    {
        //    //        foreach (Basket d in custDict[idinput].PurchaseHistory)
        //    //        {
        //    //            foreach (Product p in d.Itembasket)
        //    //            {
        //    //                sw4.WriteLine($"{idinput},{p.productID},{p.productName},{p.productCategory},{p.productCount},{p.productPrice}");
        //    //            }
        //    //        }
        //    //    }
        //    //}
        //    foreach (var dic in custDict)
        //    {
        //        if (dic.Value.PurchaseHistory.Count > 0)
        //        {


        //            foreach (var prod in dic.Value.PurchaseHistory)
        //            {
        //                sw4.WriteLine($"{dic.Key},{prod.productID},{prod.ProductName},{prod.productCount},{prod.productPrice},{prod.productCategory},{prod.dtadded}");
        //            }



        //        }
        //    }
        //    sw4.Close();
        //    fs4.Close();
        //    return "completed writing to purchasehistory.txt";
        //}
    
    public Dictionary<string, Customer> retrievecus()
        {
            //Dictionary<string, Customer> cusDict = new Dictionary<string, Customer>();
            //string filepath = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\customerdict.txt";
            //List<string> lines = File.ReadAllLines(filepath).ToList();
            //foreach (var line in lines)
            //{
            //    string[] entires = line.Split(',');

            //    Customer tempcus = new Customer(entires[0], entires[1], entires[2], entires[3], entires[4]);
            //    cusDict.Add(entires[0], tempcus);
            //    //List<string> booklst = new List<string>();
            //    Console.WriteLine("added user "+entires[0]);
            //}
            //string filepath2 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\purchasehistory.txt";
            //List<string> lines2 = File.ReadAllLines(filepath2).ToList();
            //foreach (var line in lines2)
            //{
            //    if (!string.IsNullOrWhiteSpace(line))
            //    {
            //        string[] entires = line.Split(',');
            //        try
            //        {
            //            int prodcoun = int.Parse(entires[3]);
            //            double prodcost = double.Parse(entires[4]);
            //            DateTime dtadded = DateTime.Parse( entires[6]);
            //            Product p = new Product(entires[1], entires[2], prodcoun, prodcost, entires[5]);
            //            p.dtadded = dtadded;
            //            if (cusDict.ContainsKey(entires[0]))
            //            {




            //                cusDict[entires[0]].PurchaseHistory.Add(p);
            //                Console.WriteLine("added purchase history");

            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine("in purchase hist" + e.Message);
            //        }

            //    }

            //}
            //string filepath4 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\SmartBasket.txt";
            //List<string> lines4 = File.ReadAllLines(filepath4).ToList();
            //foreach (var line in lines4)
            //{

            //    if (!string.IsNullOrWhiteSpace(line))
            //    {
            //        string[] entires = line.Split(',');

            //        try
            //        {
            //            bool basketbool = bool.Parse(entires[1]);
            //            if (!basketbool)
            //            {
            //                int prodcoun = int.Parse(entires[4]);
            //                double prodcost = double.Parse(entires[5]);
            //                Product p = new Product(entires[2], entires[3], prodcoun, prodcost, entires[6]);
            //                if (cusDict.ContainsKey(entires[0]))
            //                {

            //                    cusDict[entires[0]].bas.Itembasket.Add(p);
            //                    Console.WriteLine("added smart basket");



            //                }
            //            }

            //        }

            //        catch (Exception e)
            //        {
            //            Console.WriteLine("in smart bask" + e.Message);
            //        }
            //    }

            //}
            Dictionary<string, Customer> cusDict = new Dictionary<string, Customer>();

            cusDict = JsonConvert.DeserializeObject<Dictionary<string, Customer>>(File.ReadAllText("customerdict.json"));
            return cusDict;
        }
        public Dictionary<string, Product> retrieveInventory()
        {
            Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
            //string filepath3 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\inventory.txt";
            //List<string> lines3 = File.ReadAllLines(filepath3).ToList();
            //foreach (var line in lines3)
            //{
            //    if (!string.IsNullOrWhiteSpace(line))
            //    {
            //        string[] entires = line.Split(',');
            //        try
            //        {
            //            int prodcount = int.Parse(entires[2]);
            //            double prodprice = double.Parse(entires[3]);
            //            prodDict.Add(entires[0], new Product(entires[0], entires[1], prodcount, prodprice, entires[4]));
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine("in inventory" + e.Message);
            //        }
            //    }


            //}


            prodDict = JsonConvert.DeserializeObject<Dictionary<string, Product>>(File.ReadAllText("inventory.json"));
            return prodDict;

        }
        public Dictionary<string, string> retrievecategories(Dictionary<string, Product> prodic)
        {
            Dictionary<string, string> catdict = new Dictionary<string, string>();
            //string filepath3 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\inventory.txt";
            //List<string> lines3 = File.ReadAllLines(filepath3).ToList();
            //foreach (var line in lines3)
            //{
            //    if (!string.IsNullOrWhiteSpace(line))
            //    {
            //        try
            //        {
            //            string[] entires = line.Split(',');
            //            string cat = entires[4];
            //            if (!catdict.ContainsKey(cat))
            //            {
            //                catdict.Add(cat, cat);
            //            }
            //        }
            //        catch(Exception e)
            //        {
            //            Console.WriteLine(e.Message);
            //        }
            //    }



            //}
            foreach (var prod in prodic)
            {
                if (!catdict.ContainsKey(prod.Value.productCategory))
                {
                    catdict.Add(prod.Value.productCategory, prod.Value.productCategory);
                }
            }
            return catdict;
        }


    }
}


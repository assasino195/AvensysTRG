using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class initialize
    {
        public Dictionary<string,Customer> retrievecus()
        {
            Dictionary<string, Customer> cusDict = new Dictionary<string, Customer>();
            string filepath = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\customerdict.txt";
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entires = line.Split(',');

                Customer tempcus = new Customer(entires[0], entires[1], entires[2], entires[3], entires[4]);
                cusDict.Add(entires[0], tempcus);
                //List<string> booklst = new List<string>();
                Console.WriteLine("added user "+entires[0]);
            }
            string filepath2 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\purchasehistory.txt";
            List<string> lines2 = File.ReadAllLines(filepath2).ToList();
            foreach (var line in lines2)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entires = line.Split(',');
                    try
                    {
                        int prodcoun = int.Parse(entires[3]);
                        double prodcost = double.Parse(entires[4]);
                        DateTime dtadded = DateTime.Parse( entires[6]);
                        Product p = new Product(entires[1], entires[2], prodcoun, prodcost, entires[5]);
                        p.dtadded = dtadded;
                        if (cusDict.ContainsKey(entires[0]))
                        {




                            cusDict[entires[0]].PurchaseHistory.Add(p);
                            Console.WriteLine("added purchase history");

                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("in purchase hist" + e.Message);
                    }

                }

            }
            string filepath4 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\SmartBasket.txt";
            List<string> lines4 = File.ReadAllLines(filepath4).ToList();
            foreach (var line in lines4)
            {

                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entires = line.Split(',');

                    try
                    {
                        bool basketbool = bool.Parse(entires[1]);
                        if (!basketbool)
                        {
                            int prodcoun = int.Parse(entires[4]);
                            double prodcost = double.Parse(entires[5]);
                            Product p = new Product(entires[2], entires[3], prodcoun, prodcost, entires[6]);
                            if (cusDict.ContainsKey(entires[0]))
                            {

                                cusDict[entires[0]].bas.Itembasket.Add(p);
                                Console.WriteLine("added smart basket");



                            }
                        }

                    }

                    catch (Exception e)
                    {
                        Console.WriteLine("in smart bask" + e.Message);
                    }
                }

            }

            return cusDict;
        }
        public Dictionary<string, Product> retrieveInventory()
        {
            Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
            string filepath3 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\inventory.txt";
            List<string> lines3 = File.ReadAllLines(filepath3).ToList();
            foreach (var line in lines3)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entires = line.Split(',');
                    try
                    {
                        int prodcount = int.Parse(entires[2]);
                        double prodprice = double.Parse(entires[3]);
                        prodDict.Add(entires[0], new Product(entires[0], entires[1], prodcount, prodprice, entires[4]));
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("in inventory" + e.Message);
                    }
                }


            }
            return prodDict;

        }
        public Dictionary<string,string> retrievecategories()
        {
            Dictionary<string, string> catdict = new Dictionary<string, string>();
            string filepath3 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\FinalProj\SmartBasket\SmartBasket\bin\Debug\inventory.txt";
            List<string> lines3 = File.ReadAllLines(filepath3).ToList();
            foreach (var line in lines3)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    string[] entires = line.Split(',');
                    string cat = entires[4];
                    if(!catdict.ContainsKey(cat))
                    {
                        catdict.Add(cat, cat);
                    }
                }


            }
            return catdict;
        }
        
                
    }
   
}

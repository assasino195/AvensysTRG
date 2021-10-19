using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartBasket
{
    class Program
    {
        static Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
        static Dictionary<string, Customer> custDict = new Dictionary<string, Customer>();
        static Dictionary<string, Basket> baskdict = new Dictionary<string, Basket>();
    
        public static void init()
        {
            //all vege=1-99
            //all meat=100-199
            //all dairy=200-299

            ///all to be commented out once file we start using file stream
            //prodDict.Add("1", new Product("1", "Brocolli", 5, 1.5, "Vegetables"));
            //prodDict.Add("2", new Product("2", "BellPepper", 20, 3, "Vegetables"));
            //prodDict.Add("100", new Product("100", "A5 Wagyu", 5, 100, "Meat"));
            //prodDict.Add("200", new Product("100", "Fresh Milk", 10, 4.50, "Dairy"));
            //custDict.Add("1", new Customer("1", "John", "LOL@hotmail.com", "98754321", "Member"));
            initialize initcs = new initialize();
            custDict = initcs.retrievecus();//initialize customer details,purchase history & smart basket txt
            prodDict = initcs.retrieveInventory();//initialize inventory.txt
        }

        public static void Operation()
        {

            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Enter todays date");
                string dateinput = Console.ReadLine();
                DateTime.TryParse(dateinput, out DateTime todaysdate);
                //List<Product> tempbasket = new List<Product>();
                Basket tempbask = new Basket(false);
                Console.WriteLine("Enter your ID or Q to exit");
                string idinput = Console.ReadLine().ToLower();
                if (custDict.ContainsKey(idinput))
                {
                    foreach (var cusdic in custDict)
                    {
                        if (cusdic.Key.Equals(idinput))
                        {
                            if (cusdic.Value.role.Equals("Member"))
                            {
                                
                              
                                bool inmenu = true;
                                while (inmenu)
                                {
                                    Console.WriteLine("1.Shop for products\n2.View Basket\n3.Exit");
                                    string optin = Console.ReadLine();

                                    switch (optin)
                                    {
                                        case "1":
                                            {
                                                bool stayinbuymenu = true;
                                                while (stayinbuymenu)
                                                {
                                                    selectingProducts selectprod = new selectingProducts();
                                                    Console.WriteLine();
                                                    Console.WriteLine("1.Vegetables\n2.Meat\n3.Dairy Products");
                                                    Console.WriteLine("Q. Back");
                                                    string catopt = Console.ReadLine().ToUpper();

                                                    switch (catopt)
                                                    {
                                                        case "1":
                                                            {
                                                                Product temprod = selectprod.ShopForVege(prodDict);
                                                                if (temprod != null)
                                                                {
                                                                   
                                                                    cusdic.Value.bas.Itembasket.Add(temprod);
                                                                }
                                                                else
                                                                {
                                                                    selectprod.ShopForVege(prodDict);
                                                                }


                                                                break;
                                                            }
                                                        case "2":
                                                            {
                                                                Product temprod = selectprod.ShopForMeat(prodDict);
                                                                if (temprod != null)
                                                                {

                                                                    cusdic.Value.bas.Itembasket.Add(temprod);
                                                                }
                                                               

                                                                break;
                                                            }
                                                        case "3":
                                                            {


                                                                Product temprod = selectprod.ShopForDairy(prodDict);
                                                                if (temprod != null)
                                                                {

                                                                    cusdic.Value.bas.Itembasket.Add(temprod);
                                                                }
                                                                break;
                                                            }
                                                        case "Q":
                                                            {
                                                                stayinbuymenu = false;
                                                                break;
                                                            }
                                                    }

                                                }
                                                break;
                                            }
                                        case "2":
                                            {
                                                foreach (var items in cusdic.Value.bas.Itembasket)
                                                {
                                                    string temp = $"{items.productID}. {items.productName}\t Price is: ${string.Format("{0:N2}", items.productPrice)}\t " +
                                                                                $"Quantity to purchase: {items.productCount}";
                                                    Console.WriteLine(temp);
                                                    Console.WriteLine();
                                                    //Console.WriteLine(items);
                                                }
                                                Console.WriteLine($"Total Cost Is {cusdic.Value.bas.calculatetotal()}");
                                                Console.WriteLine("Do You Wish To Check Out? Y/N");
                                                string checkingout = Console.ReadLine().ToUpper();
                                                if (checkingout.Equals("Y"))
                                                {
                                                    cusdic.Value.bas.isCheckedOut = true;
                                                    foreach (var prod in cusdic.Value.bas.Itembasket)
                                                    {
                                                        if (prodDict.ContainsKey(prod.productID))
                                                        {
                                                            prodDict[prod.productID].productCount = prodDict[prod.productID].productCount - prod.productCount;
                                                            cusdic.Value.PurchaseHistory.Add(prod);
                                                        }
                                                    }
                                                   
                                                    cusdic.Value.bas.Itembasket.Clear();
                                                    //purchaseHist.Add(tempbask);
                                                    inmenu = false;
                                                }

                                                break;
                                            }
                                        case "3":
                                            {
                                                foreach (var p in cusdic.Value.PurchaseHistory)
                                                {
                                                   
                                                        Console.WriteLine($"{ p.productID} { p.productName} { p.productCount} { p.productPrice} { p.productCategory}");
                                                    
                                                }
                                                break;
                                            }
                                        case "q":
                                            {

                                                inmenu = false;
                                                baskdict.Add(idinput, tempbask);
                                                break;
                                            }
                                    }
                                }
                            }
                            else if (cusdic.Value.role.Equals("Manager"))
                            {
                                Console.WriteLine("1.Add New Product\n2.Generate Sales Report");
                                string manageroptinput = Console.ReadLine();
                                switch (manageroptinput)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("1.Vegetables\n2.Meat\n3.Dairy Products");
                                            Console.WriteLine("Q. Back");
                                            string addprodinput = Console.ReadLine();
                                            switch (addprodinput)
                                            {
                                                case "1":
                                                    {
                                                        CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                        Product temp = createnewprod.AddingNewProduct("Vegetables");
                                                        if (temp != null)
                                                        {
                                                            prodDict.Add(temp.productID, temp);
                                                        }

                                                        break;
                                                    }
                                                case "2":
                                                    {
                                                        CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                        Product temp = createnewprod.AddingNewProduct("Meat");
                                                        if (temp != null)
                                                        {
                                                            prodDict.Add(temp.productID, temp);
                                                        }
                                                        break;
                                                    }
                                                case "3":
                                                    {
                                                        CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                        Product temp = createnewprod.AddingNewProduct("Dairy");
                                                        if (temp != null)
                                                        {
                                                            prodDict.Add(temp.productID, temp);
                                                        }
                                                        break;
                                                    }
                                            }
                                            break;
                                        }
                                    case "2":
                                        {
                                            GenerateSalesReport gensalesreport = new GenerateSalesReport();
                                            gensalesreport.generatesalesreport(custDict);
                                            break;
                                        }
                                }

                            }
                        }
                       
                    }
                }
                else if (idinput.Equals("q"))
                {
                    stay = false;


                    WritingToTextFile writetotext = new WritingToTextFile();
                    writetotext.writingToCustomerTxt(custDict);
                    writetotext.writingToInventoryTxt(prodDict);
                    writetotext.writingToSmartBasketTxt(custDict);
                    writetotext.WritingToPurchaseHistory(custDict);
                    
                   
                    
                }
                else
                {

                    CreatingNewCustomer createnewcust = new CreatingNewCustomer();
                    Customer tempcus= createnewcust.createcustomer(idinput);
                    if(tempcus!=null)
                    {
                        custDict.Add(idinput, tempcus);
                    }
                }


            }
        }
       
        static void Main(string[] args)
        {
            init();
            Operation();
            Console.ReadLine();

        }
    }
}

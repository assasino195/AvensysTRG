using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SmartBasket
{
    public class Program
    {
        static Dictionary<string, Product> prodDict = new Dictionary<string, Product>();
        static Dictionary<string, Customer> custDict = new Dictionary<string, Customer>();
        static Dictionary<string, Basket> baskdict = new Dictionary<string, Basket>();
        static Dictionary<string, string> prodcategories = new Dictionary<string, string>();
    
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
            prodcategories = initcs.retrievecategories();
        }

        public static void Operation()
        {

            bool stay = true;
            while (stay)
            {

                //Console.WriteLine("Enter todays date");
                //string date = Console.ReadLine();
                //DateTime dateinput=DateTime.Parse(date);
                DateTime dateinput = DateTime.UtcNow;
                
                //DateTime.TryParse(dateinput, out DateTime todaysdate);
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
                                    Console.Clear();
                                    Console.WriteLine("1.Shop for products\n2.View Basket\n3.View Purchase History\nq.Exit");
                                    string optin = Console.ReadLine();

                                    switch (optin)
                                    {
                                        case "1":
                                            {
                                                bool stayinbuymenu = true;
                                                while (stayinbuymenu)
                                                {
                                                    selectingProducts selectprod = new selectingProducts();
                                                    Console.Clear();
                                                    //Console.WriteLine("1.Vegetables\n2.Meat\n3.Dairy Products");
                                                    int menucount = 1;
                                                    foreach(var d in prodcategories)
                                                    {
                                                        Console.WriteLine($"{menucount}. {d.Value}");
                                                        menucount++;
                                                    }
                                                    Console.WriteLine("Q. Back");
                                                    string catopt = Console.ReadLine().ToUpper();

                                                    switch (catopt)
                                                    {
                                                        case "1":
                                                            {
                                                               List<string> prodlist= selectprod.displayproducts(prodDict, "Vegetables");
                                                                foreach(string prod in prodlist)
                                                                {
                                                                    Console.WriteLine(prod);
                                                                }
                                                                Console.WriteLine("Enter Option of item you wish to buy");
                                                                string itemopt = Console.ReadLine();
                                                                if (prodDict.ContainsKey(itemopt))
                                                                {
                                                                    Console.WriteLine("Enter Quantity you wish to buy");
                                                                    try
                                                                    {
                                                                        int quant = int.Parse(Console.ReadLine());
                                                                        if (prodDict[itemopt].productCount < quant)
                                                                        {
                                                                            Console.WriteLine("Exceeded the amount of stock we have please lower the count");
                                                                           
                                                                        }
                                                                        else
                                                                        {
                                                                            Product tempp= selectprod.ShopForProduct(prodDict, itemopt, quant);

                                                                            if (tempp != null)
                                                                            {

                                                                                cusdic.Value.bas.Itembasket.Add(tempp);
                                                                                Console.WriteLine("Added to basket");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("failed please try again");
                                                                            }
                                                                            


                                                                            //cusdic.Value.bas.Itembasket.Add(tempp); ;
                                                                           
                                                                            
                                                                        }
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        Console.WriteLine("Enter a valid Number");
                                                                       
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Enter a Valid Option");
                                                                    
                                                                }
                                                               
                                                               


                                                                break;
                                                            }
                                                        case "2":
                                                            {
                                                                List<string> prodlist = selectprod.displayproducts(prodDict, "Meat");
                                                                foreach (string prod in prodlist)
                                                                {
                                                                    Console.WriteLine(prod);
                                                                }
                                                                Console.WriteLine("Enter Option of item you wish to buy");
                                                                string itemopt = Console.ReadLine();
                                                                if (prodDict.ContainsKey(itemopt))
                                                                {
                                                                    Console.WriteLine("Enter Quantity you wish to buy");
                                                                    try
                                                                    {
                                                                        int quant = int.Parse(Console.ReadLine());
                                                                        if (prodDict[itemopt].productCount < quant)
                                                                        {
                                                                            Console.WriteLine($"{prodDict[itemopt].productID} {prodDict[itemopt].productName} is no longer available");

                                                                        }
                                                                        else
                                                                        {
                                                                            Product tempp = selectprod.ShopForProduct(prodDict, itemopt, quant);

                                                                            if (tempp != null)
                                                                            {

                                                                                cusdic.Value.bas.Itembasket.Add(tempp);
                                                                                Console.WriteLine("Added to basket");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("failed please try again");
                                                                            }



                                                                            //cusdic.Value.bas.Itembasket.Add(tempp); ;


                                                                        }
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        Console.WriteLine("Enter a valid Number");

                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    Console.WriteLine("Enter a Valid Option");

                                                                }


                                                                break;
                                                            }
                                                        case "3":   
                                                            {

                                                                List<string> prodlist = selectprod.displayproducts(prodDict, "Dairy");
                                                                foreach (string prod in prodlist)
                                                                {
                                                                    Console.WriteLine(prod);
                                                                }
                                                                Console.WriteLine("Enter Option of item you wish to buy");
                                                                string itemopt = Console.ReadLine();
                                                                if (prodDict.ContainsKey(itemopt))
                                                                {
                                                                    Console.WriteLine("Enter Quantity you wish to buy");
                                                                    try
                                                                    {
                                                                        int quant = int.Parse(Console.ReadLine());
                                                                        if (prodDict[itemopt].productCount < quant)
                                                                        {
                                                                            Console.WriteLine("Exceeded the amount of stock we have please lower the count");

                                                                        }
                                                                        else
                                                                        {
                                                                            Product tempp = selectprod.ShopForProduct(prodDict, itemopt, quant);

                                                                            if (tempp != null)
                                                                            {

                                                                                cusdic.Value.bas.Itembasket.Add(tempp);
                                                                                Console.WriteLine("Added to basket");
                                                                            }
                                                                            else
                                                                            {
                                                                                Console.WriteLine("failed please try again");
                                                                            }



                                                                            //cusdic.Value.bas.Itembasket.Add(tempp); ;


                                                                        }
                                                                    }
                                                                    catch (Exception)
                                                                    {
                                                                        Console.WriteLine("Enter a valid Number");

                                                                    }
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
                                                selectingProducts selectprod = new selectingProducts();
                                                Console.Clear();
                                                HotsellingItems hotitem = new HotsellingItems();
                                                foreach (var items in cusdic.Value.bas.Itembasket)
                                                {
                                                    string temp = $"{items.productID}. {items.productName}\t Price is: ${string.Format("{0:N2}", items.productPrice)}\t " +
                                                                                $"Quantity to purchase: {items.productCount}";
                                                    Console.WriteLine(temp);
                                                    Console.WriteLine();
                                                    //Console.WriteLine(items);
                                                }
                                                Console.WriteLine($"Total Cost Is {cusdic.Value.bas.calculatetotal()}");
                                                Console.WriteLine();
                                                Console.WriteLine("Hot Items in Market At The Moment");
                                                foreach(var prod in hotitem.displayHotItems(custDict))
                                                {
                                                    if(prodDict.ContainsKey(prod.productID))
                                                    {
                                                        Console.WriteLine($"{prodDict[prod.productID].productID}. {prodDict[prod.productID].productName}\t Quantity:{prodDict[prod.productID].productCount} at: ${prodDict[prod.productID].productPrice}");
                                                        
                                                    }
                                                }
                                                Console.WriteLine("Do you wish to add any of this items? Y/N");
                                                string addingitems = Console.ReadLine().ToLower();
                                                if(addingitems.Equals("y"))
                                                {
                                                    Console.WriteLine("Enter Item ID you wish to add");
                                                    string itemid = Console.ReadLine();
                                                    if(prodDict.ContainsKey(itemid))
                                                    {
                                                        Console.WriteLine("Enter Quantity you wish to purchase");
                                                        try
                                                        {
                                                            int quant= int.Parse(Console.ReadLine());
                                                            if (quant < prodDict[itemid].productCount)
                                                            {
                                                                cusdic.Value.bas.Itembasket.Add(selectprod.ShopForProduct(prodDict, itemid, quant));
                                                            }
                                                            else
                                                            {
                                                                Console.WriteLine($"Not Enough Stock We have Only {prodDict[itemid].productCount} in stock");
                                                            }
                                                        }
                                                        catch(Exception e)
                                                        {
                                                            Console.WriteLine(  e.Message);
                                                        }
                                                     
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Please Enter a valid product ID");
                                                    }
                                                    Console.WriteLine("Press any button to continue");
                                                    Console.ReadLine();
                                                    break;
                                                }
                                                Console.WriteLine("1.Check Out\n2.Remove Product\n3.Exit");

                                                string checkingout = Console.ReadLine().ToUpper();
                                                if (checkingout.Equals("1"))
                                                {
                                                    cusdic.Value.bas.isCheckedOut = true;
                                                    foreach (var prod in cusdic.Value.bas.Itembasket)
                                                    {
                                                        if (prodDict.ContainsKey(prod.productID))
                                                        {
                                                            if (prodDict[prod.productID].productCount < prod.productCount)
                                                            {
                                                                Console.WriteLine($"Please redo your basket {prod.productName} is no longer available in the store");
                                                            }
                                                            else
                                                            {
                                                                prodDict[prod.productID].productCount = prodDict[prod.productID].productCount - prod.productCount;
                                                                prod.dtadded = dateinput;
                                                                cusdic.Value.PurchaseHistory.Add(prod);
                                                            }
                                                        }
                                                    }
                                                   
                                                    cusdic.Value.bas.Itembasket.Clear();
                                                    //purchaseHist.Add(tempbask);
                                                    inmenu = false;
                                                }
                                                else if(checkingout.Equals("2"))
                                                {
                                                    bool removed = false;
                                                    Console.WriteLine("enter the ID of the product you wish to remove");
                                                    string removeid = Console.ReadLine();
                                                    foreach(var prod in cusdic.Value.bas.Itembasket)
                                                    {
                                                       
                                                        if(prod.productID==removeid)
                                                        {
                                                            cusdic.Value.bas.Itembasket.Remove(prod);
                                                            Console.WriteLine("Item successfully removed");
                                                            removed = true;
                                                            break;
                                                        }
                                                        
                                                    }
                                                    if(removed)
                                                    {
                                                        Console.WriteLine("Item has been removed: " + removed);
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Item Not Found");
                                                    }
                                                    
                                                }

                                                break;
                                            }
                                        case "3":
                                            {
                                                foreach (var p in cusdic.Value.PurchaseHistory)
                                                {
                                                   
                                                        Console.WriteLine($"On {p.dtadded}\t you purchased {p.productCount} product ID: { p.productID}\t{ p.productName}\t at a price of { p.productPrice} { p.productCategory}");
                                                    
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
                                Console.Clear();
                                string newprodname = string.Empty;
                                string newprodID = string.Empty;
                                int stock = 0;                              
                                double price =0 ;
                                Console.WriteLine("1.Add new Products\n2.Generate Sales Report\n3.Display All Products in store\n4.Remove Product\nQ.Exit");
                                string manageroptinput = Console.ReadLine();
                                switch (manageroptinput)
                                {
                                    case "1":
                                        {
                                            Console.WriteLine("1.Vegetables\n2.Meat\n3.Dairy Products");
                                            Console.WriteLine("Q. Back");
                                            string addprodinput = Console.ReadLine();
                                            try
                                            {


                                                Console.WriteLine("Enter New Product Name");
                                                 newprodname = Console.ReadLine();
                                                Console.WriteLine("Enter ID of new Product");
                                                 newprodID = Console.ReadLine();
                                                Console.WriteLine("Enter New Product Stock Quantity");
                                                 stock = int.Parse(Console.ReadLine());
                                                Console.WriteLine("Enter Price of New Product");
                                                 price = double.Parse(Console.ReadLine());
                                                switch (addprodinput)
                                                {
                                                    case "1":
                                                        {
                                                            CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                            Product temp = createnewprod.AddingNewProduct(newprodID, newprodname, stock, price, "Vegetables");
                                                            if (temp != null)
                                                            {
                                                                prodDict.Add(temp.productID, temp);
                                                            }

                                                            break;
                                                        }
                                                    case "2":
                                                        {
                                                            CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                            Product temp = createnewprod.AddingNewProduct(newprodID,newprodname,stock,price,"Meat");
                                                            if (temp != null)
                                                            {
                                                                prodDict.Add(temp.productID, temp);
                                                            }
                                                            break;
                                                        }
                                                    case "3":
                                                        {
                                                            CreatingNewProduct createnewprod = new CreatingNewProduct();
                                                            Product temp = createnewprod.AddingNewProduct(newprodID,newprodname,stock,price,"Dairy");
                                                            if (temp != null)
                                                            {
                                                                prodDict.Add(temp.productID, temp);
                                                            }
                                                            break;
                                                        }

                                                }
                                            }
                                            catch (Exception e)
                                            {
                                                Console.WriteLine(e.Message);
                                                
                                            }
                                           
                                            break;
                                        }
                                    case "2":
                                        {
                                            GenerateSalesReport gensalesreport = new GenerateSalesReport();
                                            List<string> temp = gensalesreport.generatesalesreport(custDict);
                                            foreach(string reports in temp)
                                            {
                                                Console.WriteLine(reports);
                                            }
                                           // gensalesreport.generatesalesreport(custDict);
                                            break;
                                        }
                                    case "3":
                                        {
                                            foreach(var prod in prodDict)
                                            {
                                                Console.WriteLine($"{prod.Value.productID}: {prod.Value.productName}\tQuantity: {prod.Value.productCount}\tat {prod.Value.productPrice}");
                                            }
                                            break;
                                        }
                                    case "4":
                                        {
                                            foreach (var prod in prodDict)
                                            {
                                                Console.WriteLine($"{prod.Value.productID}: {prod.Value.productName}\tQuantity: {prod.Value.productCount}\tat {prod.Value.productPrice}");
                                            }
                                            Console.WriteLine("enter the ID of the product you wish to remove");
                                            string removeid = Console.ReadLine();
                                            if(prodDict.ContainsKey(removeid))
                                            {
                                                Console.WriteLine($"{prodDict[removeid].productID} has been successfully removed");
                                                prodDict.Remove(removeid);
                                               
                                            }
                                            else
                                            {
                                                Console.WriteLine("Item Not Found");
                                            }
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
                    Console.WriteLine("Enter your name");
                    string nameinput = Console.ReadLine();
                    Console.WriteLine("Enter Your Email");
                    string emailinput = Console.ReadLine();
                    Console.WriteLine("Enter Your Phone No");
                    string phonenoinput = Console.ReadLine();
                    Customer tempcus= createnewcust.createcustomer(idinput,nameinput,emailinput,phonenoinput);
                    if(tempcus!=null)
                    {
                        custDict.Add(idinput, tempcus);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Email or Phone Number");
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

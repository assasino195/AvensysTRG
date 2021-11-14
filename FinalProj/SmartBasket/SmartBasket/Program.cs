using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;


namespace SmartBasket
{
    public class Program
    {

        static readonly HttpClient client = new HttpClient();
        static accountmanagerHttp accmanager = new accountmanagerHttp(client);
        static ManagerServicesHttp managerservices = new ManagerServicesHttp(client);
        static BasketManagerHttp basketmanager = new BasketManagerHttp(client);
        static ConsoleIO consoleio = new ConsoleIO();


        

        static async Task Main(string[] args)
        {
            int id = 0;

            bool stay = true;
            while (stay)
            {


                Console.WriteLine("Enter your ID or Q to exit");
                string idinput = Console.ReadLine().ToLower();
                try
                {
                    id = int.Parse(idinput);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
                Customer c = await accmanager.Login(id);
                if (c != null)
                {

                    if (c.role.Equals("customer"))
                    {


                        bool inmenu = true;
                        while (inmenu)
                        {
                            //Console.Clear();
                            Console.WriteLine("1.Shop for products\n2.View Basket\n3.View Purchase History\nq.Exit");
                            string optin = Console.ReadLine();

                            switch (optin)
                            {
                                case "1":
                                    {
                                        try
                                        {
                                            // Console.Clear();
                                            consoleio.displayprods(await basketmanager.displayprod());
                                            Console.WriteLine("Do you wish to add product? Y/N");
                                            string addingproduct = Console.ReadLine().ToLower();
                                            int prodid = 0;
                                            int count = 0;
                                            if (addingproduct.Equals("y"))
                                            {
                                                try
                                                {
                                                    Console.WriteLine("Enter product ID");
                                                    prodid = int.Parse(Console.ReadLine());
                                                    Console.WriteLine("enter quantity");
                                                    count = int.Parse(Console.ReadLine());
                                                    Console.WriteLine(await basketmanager.shopforprod(prodid, count, c.customerID));
                                                }
                                                catch (Exception e)
                                                {
                                                    Console.WriteLine(e.Message);
                                                }

                                            }
                                            
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        // Console.WriteLine(await basketmanager.displayprod());
                                       






                                        break;
                                    }
                                case "2":
                                    {
                                        try
                                        {
                                            consoleio.viewbasket(await basketmanager.viewbasket(c.customerID));
                                            Console.WriteLine();
                                           consoleio.calculatetotal(await basketmanager.calculatetotal(c.customerID));

                                           // Console.WriteLine(await basketmanager.calculatetotal(c.customerID));
                                            Console.WriteLine("Do you wish to checkout? Y/N");
                                            string checkingout = Console.ReadLine().ToLower();
                                            if (checkingout.Equals("y"))
                                            {
                                                Console.WriteLine(await basketmanager.checkingout(c.customerID));
                                            }
                                        }
                                        catch(Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }

                                        break;
                                    }
                                case "3":
                                    {
                                        try
                                        {
                                            consoleio.displaypurchasehist(await basketmanager.displaypurchaseHist(c.customerID));
                                        }
                                        catch(Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        //foreach (var p in cusdic.Value.PurchaseHistory)
                                        //{

                                        //        Console.WriteLine($"On {p.dtadded}\t you purchased {p.productCount} product ID: { p.productID}\t{ p.ProductName}\t at a price of { p.productPrice} { p.productCategory}");

                                        //}
                                        break;
                                    }
                                case "q":
                                    {

                                        inmenu = false;
                                        //baskdict.Add(idinput, tempbask);
                                        break;
                                    }
                            }
                        }
                    }
                    else if (c.role.Equals("manager"))
                    {
                        Console.Clear();
                        string newprodname = string.Empty;
                        
                        int stock = 0;
                        double price = 0;
                        Console.WriteLine("1.Add new Products\n2.Generate Sales Report\n3.Display All Products in store\n4.Remove Product\nQ.Exit");
                        string manageroptinput = Console.ReadLine().ToLower();
                        bool inamanger = true;
                        while (inamanger)
                        {
                            switch (manageroptinput)
                            {
                                case "1":
                                    {

                                        try
                                        {
                                            Console.WriteLine("Enter New Product Name");
                                            newprodname = Console.ReadLine();
                                            Console.WriteLine("Enter New Product Stock Quantity");
                                            stock = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Enter product category");
                                            string category = Console.ReadLine();
                                            Console.WriteLine("Enter Price of New Product");
                                            price = double.Parse(Console.ReadLine());
                                            Console.WriteLine(await managerservices.addprod(consoleio.addprod(newprodname, stock, price, category)));



                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);

                                        }
                                        Console.ReadLine();
                                        break;
                                    }
                                case "2":
                                    {
                                        try
                                        {

                                            consoleio.displaysalesreport(await managerservices.salesreport());
                                            
                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.ReadLine();
                                        break;
                                    }
                                case "3":
                                    {
                                        consoleio.displayprods(await basketmanager.displayprod());
                                        Console.ReadLine();
                                        break;
                                    }
                                case "4":
                                    {
                                        try
                                        {
                                            Console.WriteLine("Enter product ID you wish to remove");
                                            int prodid = int.Parse(Console.ReadLine());
                                            Console.WriteLine(await managerservices.removeprod(prodid));

                                        }
                                        catch (Exception e)
                                        {
                                            Console.WriteLine(e.Message);
                                        }
                                        Console.ReadLine();
                                        break;
                                    }
                                case "q":
                                    {
                                        inamanger = false;
                                        break;
                                    }
                                case "5":
                                    {
                                        consoleio.viewallcustomers(await managerservices.retrievecustomer());
                                        Console.ReadLine();
                                        break;
                                    }
                                default:
                                    {
                                        Console.WriteLine("Enter a valid option");
                                        
                                        break;
                                    }
                            }
                        }

                    }
                }




                else if (idinput.Equals("q"))
                {
                    stay = false;
                }
                else if(idinput.Equals(""))
                {

                }
                else
                {
                    try
                    {
                        Console.WriteLine("Enter your name");
                        string nameinput = Console.ReadLine();
                        Console.WriteLine("Enter Your Email");
                        string emailinput = Console.ReadLine();
                        Console.WriteLine("Enter Your Phone No");
                        string phonenoinput = Console.ReadLine();
                        Console.WriteLine(await accmanager.addcustomer(consoleio.creatingnewcustomer(nameinput, emailinput, phonenoinput))); 
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }


                    // Customer tempcus= createnewcust.createcustomer(idinput,nameinput,emailinput,phonenoinput);
                    //if(tempcus!=null)
                    //{
                    //    custDict.Add(idinput, tempcus);
                    //}
                    //else
                    //{
                    //    Console.WriteLine("Invalid Email or Phone Number");
                    //}
                }


            }
            // init();

            //Operation();
            Console.ReadLine();

        }
    }
}

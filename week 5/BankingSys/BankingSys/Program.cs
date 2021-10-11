using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSys
{
    class Program
    {
        public static void cusmenu()
        {
            Console.WriteLine("How can we help you today?");
            Console.WriteLine("1. Apply for loan");
            Console.WriteLine("2. Submit documents for verification");
            Console.WriteLine("3. Negotiate for loans");
            Console.WriteLine("4. submit all documents for final approval");
        }
        static void Main(string[] args)
        {
            List<employee> emplst = new List<employee>();
            List<customer> custlst = new List<customer>();
            List<string> roles = new List<string>();
            roles.Add("loan officer");
            roles.Add("Verification officer");
            roles.Add("Negotiate officer");
            roles.Add("final approval  officer");

            emplst.Add(new employee("Manager", "john", "1"));
            emplst.Add(new employee("loan officer", "larry", "2"));
            emplst.Add(new employee("Verification Officer", "mary", "3"));
            emplst.Add(new employee("Negotiate Officer", "timothy", "4"));
            emplst.Add(new employee("final approval officer", "Adam", "5"));
            emplst.Add(new employee("loan officer", "Tiffany", "6"));
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Welcome to the bank today");
                Console.WriteLine("please enter todays date");
                bool pass = DateTime.TryParse(Console.ReadLine(), out DateTime dtinput);
                if (pass)
                {
                    bool stay2 = true;
                    while (stay2)
                    {
                        Console.WriteLine($"1.Customer\n2.Employee");
                        string input1 = Console.ReadLine();
                        switch (input1)
                        {
                            case "1":
                                {
                                    Console.WriteLine("PLease enter your name");
                                    string cusname = Console.ReadLine();
                                    Console.WriteLine("Please enter ur ID");
                                    string customerID = Console.ReadLine();
                                    foreach (customer cs in custlst)
                                    {
                                        if (cs.id.Equals(customerID))
                                        {
                                            cs.lastvisited = dtinput;
                                            cusmenu();
                                            string cusopt = Console.ReadLine();
                                            foreach (employee e in emplst)
                                            {
                                                e.todaysdate = dtinput;
                                                switch (cusopt)
                                                {
                                                    case "1":
                                                        {
                                                           // foreach (employee e in emplst)
                                                            //{
                                                                if (e.role.Equals(roles[0]))
                                                                {
                                                                    Console.WriteLine($"{e.name} will be assigned to serve u");
                                                                    e.logsvc(cs);
                                                                    cs.servicesgiven.Add($"{e.name} {e.id} served {cs.name} {e.role} on {dtinput}");
                                                                }
                                                           // }
                                                            break;
                                                        }
                                                    case "2":
                                                        {
                                                           // foreach (employee e in emplst)
                                                           // {
                                                                if (e.role.Equals(roles[1]))
                                                                {
                                                                    Console.WriteLine($"{e.name} will be assigned to serve u");
                                                                }
                                                           // }
                                                            break;
                                                        }
                                                    case "3":
                                                        {
                                                           // foreach (employee e in emplst)
                                                           // {
                                                                if (e.role.Equals(roles[2]))
                                                                {
                                                                    Console.WriteLine($"{e.name} will be assigned to serve u");
                                                                }
                                                           // }
                                                            break;
                                                        }
                                                    case "4":
                                                        {
                                                            //foreach (employee e in emplst)
                                                            //{
                                                                if (e.role.Equals(roles[3]))
                                                                {
                                                                    Console.WriteLine($"{e.name} will be assigned to serve u");
                                                                    Console.WriteLine("Please type in ur documents");

                                                                    cs.documents = Console.ReadLine();

                                                                }
                                                           // }
                                                            break;
                                                        }
                                                    case "q":
                                                        {
                                                           // stay2 = false;
                                                            break;
                                                        }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            custlst.Add(new customer(cusname, customerID));
                                        }
                                    }
                                    break;
                                }
                            case "2":
                                {
                                    Console.WriteLine("enter your id number or Q to exit");
                                    string input2 = Console.ReadLine().ToLower();
                                    foreach (employee e in emplst)
                                    {
                                        switch (input2)
                                        {
                                            case "1":
                                                {
                                                    Console.WriteLine($"1.Assign Employee Roles\n2.Check for approvals\n3.End Day");
                                                    string input3 = Console.ReadLine();
                                                    switch (input3)
                                                    {
                                                        case "1":
                                                            {
                                                                //foreach (employee e in emplst)
                                                                //{
                                                                if (e.role != "Manager")
                                                                {
                                                                    int count = 0;
                                                                    Console.WriteLine(e.name + " " + e.id);
                                                                    Console.WriteLine("choose role to assign for today");
                                                                    foreach (string r in roles)
                                                                    {
                                                                        Console.WriteLine(count + ": " + r);
                                                                        count++;
                                                                    }
                                                                    int.TryParse(Console.ReadLine(), out int roleinput);
                                                                    e.role = roles[roleinput];
                                                                }
                                                                //}
                                                                break;
                                                            }
                                                        case "2":
                                                            {
                                                                if(e.role.Equals(roles[0]))
                                                                {
                                                                    foreach(customer cs in custlst)
                                                                    {
                                                                        Console.WriteLine(cs.name+" "+cs.id+" "+cs.documents+" "+cs.daysvisited);
                                                                        foreach(string a in cs.servicesgiven)
                                                                        {
                                                                            Console.WriteLine(a);
                                                                        }
                                                                        cs.checkapproval();

                                                                        Console.WriteLine($"Approved or not {cs.approvals}");
                                                                        
                                                                    }
                                                                }
                                                                break;
                                                            }
                                                        case "3":
                                                            {
                                                                stay2 = false;
                                                                //stay = false;
                                                                break;
                                                            }
                                                    }
                                                    break;
                                                }
                                            
                                            case "q":
                                                {
                                                    stay2 = false;
                                                    break;
                                                }
                                            default:
                                                {

                                                    //foreach (employee e in emplst)
                                                    //{
                                                    if (e.id.Equals(input2))
                                                    {

                                                        Console.WriteLine($"{e.name} {e.id} your role for today is: {e.role} ");
                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("invalid id number");
                                                    }
                                                    //}
                                                    break;
                                                }
                                        }
                                    }
                                        break;
                                    
                                }

                        }
                    }
                }
            }
        }
    }
}
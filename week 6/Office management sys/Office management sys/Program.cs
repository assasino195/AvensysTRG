using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_management_sys
{
    class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, workers> dict = new Dictionary<string, workers>();
            dict.Add("1", new workers("David", "1", "SuperAdmin"));
            dict.Add("2", new workers("Adam", "2", "Admin"));
            dict.Add("3", new workers("John", "3", "User"));
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Enter your ID");
                string idinput = Console.ReadLine();
                if (dict.ContainsKey(idinput))
                {
                    bool addedworker = false;

                    foreach (var worker in dict)
                    {

                        if (worker.Key.Equals(idinput))
                        {
                            switch (worker.Value.role)
                            {
                                case "SuperAdmin":
                                    {
                                        Console.WriteLine("1.Add new employee");
                                        Console.WriteLine("2.Remove Employee");
                                        Console.WriteLine("3.Change employee role");
                                        Console.WriteLine("4.Assign task to employee");
                                        Console.WriteLine("5.Check Submitted Reports");
                                        Console.WriteLine("0.Quit");
                                        string choice = Console.ReadLine();
                                        switch (choice)
                                        {
                                            case "1":
                                                {
                                                    Console.WriteLine("Enter employee name");
                                                    string name = Console.ReadLine();
                                                    Console.WriteLine("Enter employee ID");
                                                    string id = Console.ReadLine();
                                                    Console.WriteLine("enter employee role\n1.SuperAdmin\n2.Admin\n3.User");
                                                    string inptrole = Console.ReadLine();
                                                    string role = string.Empty;
                                                    switch (inptrole)
                                                    {
                                                        case "1":
                                                            {
                                                                role = "SuperAdmin";
                                                                break;
                                                            }
                                                        case "2":
                                                            {
                                                                role = "Admin";
                                                                break;
                                                            }
                                                        case "3":
                                                            {
                                                                role = "User";
                                                                break;
                                                            }
                                                        default:
                                                            {
                                                                Console.WriteLine("invalid");
                                                                break;
                                                            }
                                                    }
                                                    if (dict.ContainsKey(id))
                                                    {
                                                        Console.WriteLine("employee already exist");
                                                    }
                                                    else
                                                    {
                                                        dict.Add(id, new workers(name, id, role));
                                                        Console.WriteLine("Added new worker!");
                                                        addedworker = true;

                                                    }
                                                    break;
                                                }
                                            case "2"://remove employee
                                                {
                                                    Console.WriteLine("Enter employee ID you wish to remove");
                                                    string input = Console.ReadLine();
                                                    if (dict.ContainsKey(input))
                                                    {

                                                        dict.Remove(input);
                                                        Console.WriteLine($"Successfully removed {input}");

                                                    }
                                                    else
                                                    {
                                                        Console.WriteLine("Invalid ID");
                                                    }
                                                    break;
                                                }
                                            case "3":
                                                {
                                                    Console.WriteLine("Enter employee ID you wish to remove");
                                                    string input = Console.ReadLine();

                                                    if (dict.ContainsKey(input))
                                                    {
                                                        foreach (var dic in dict)
                                                        {
                                                            if (dic.Key.Equals(input))
                                                            {
                                                                Console.WriteLine("enter employee role\n1.SuperAdmin\n2.Admin\n3.User");
                                                                string inptrole = Console.ReadLine();
                                                                string role = string.Empty;
                                                                switch (inptrole)
                                                                {
                                                                    case "1":
                                                                        {
                                                                            dic.Value.role = "SuperAdmin";
                                                                            break;
                                                                        }
                                                                    case "2":
                                                                        {
                                                                            dic.Value.role = "Admin";
                                                                            break;
                                                                        }
                                                                    case "3":
                                                                        {
                                                                            dic.Value.role = "User";
                                                                            break;
                                                                        }
                                                                    default:
                                                                        {
                                                                            Console.WriteLine("invalid");
                                                                            break;
                                                                        }
                                                                }

                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "4":
                                                {
                                                    foreach (var dic in dict)
                                                    {
                                                        Console.WriteLine($"{dic.Key} {dic.Value.name} {dic.Value.role}");
                                                    }
                                                    Console.WriteLine("Enter employee ID you wish to assign");
                                                    string idint = Console.ReadLine();
                                                    if (dict.ContainsKey(idint))
                                                    {
                                                        foreach (var w in dict)
                                                        {
                                                            if (w.Key.Equals(idint))
                                                            {
                                                                Console.WriteLine($"Enter task you wish to assign to {w.Value.name} {w.Value.id}");
                                                                w.Value.taskassigned = Console.ReadLine();
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "5":
                                                {
                                                    foreach (var dic in dict)
                                                    {
                                                        if (dic.Value.role == "User")
                                                        {
                                                            Console.WriteLine($"{dic.Key} {dic.Value.name} {dic.Value.role}");
                                                        }
                                                    }
                                                    Console.WriteLine("Enter employee ID you wish to view report");
                                                    string aa = Console.ReadLine();
                                                    if (dict.ContainsKey(aa))
                                                    {
                                                        foreach (var dic in dict)
                                                        {
                                                            if (dic.Key.Equals(aa))
                                                            {
                                                                foreach (string a in dic.Value.worksubmitted)
                                                                {
                                                                    Console.WriteLine(a);
                                                                }

                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "0":
                                                {
                                                    stay = false;
                                                    break;
                                                }
                                            default:
                                                {
                                                    break;
                                                }
                                        }
                                        break;
                                    }
                                case "Admin":
                                    {
                                        Console.WriteLine("1.Assign roles\n2.View Employee Reports");
                                        string aaa = Console.ReadLine();
                                        switch(aaa)
                                        {
                                            case "1":
                                                {
                                                    foreach (var dic in dict)
                                                    {
                                                        Console.WriteLine($"{dic.Key} {dic.Value.name} {dic.Value.role}");
                                                    }
                                                    Console.WriteLine("Enter employee ID you wish to assign");
                                                    string idint = Console.ReadLine();
                                                    if (dict.ContainsKey(idint))
                                                    {
                                                        foreach (var w in dict)
                                                        {
                                                            if (w.Key.Equals(idint))
                                                            {
                                                                Console.WriteLine($"Enter task you wish to assign to {w.Value.name} {w.Value.id}");
                                                                w.Value.taskassigned = Console.ReadLine();
                                                                Console.WriteLine("Assigned Task");
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "2":
                                                {
                                                    foreach (var dic in dict)
                                                    {
                                                        if (dic.Value.role == "User")
                                                        {
                                                            Console.WriteLine($"{dic.Key} {dic.Value.name} {dic.Value.role}");
                                                        }
                                                    }
                                                    Console.WriteLine("Enter employee ID you wish to view report");
                                                    string aa = Console.ReadLine();
                                                    if(dict.ContainsKey(aa))
                                                    {
                                                        foreach(var dic in dict)
                                                        {
                                                            if(dic.Key.Equals(aa))
                                                            {
                                                                foreach(string a in dic.Value.worksubmitted)
                                                                {
                                                                    Console.WriteLine(a);
                                                                }
                                                               
                                                            }
                                                        }
                                                    }
                                                    break;
                                                }
                                        }
                                       
                                        break;

                                    }
                                case "User":
                                    {
                                        Console.WriteLine($"{worker.Value.id} {worker.Value.name} ");
                                        Console.WriteLine($"Your task for today is {worker.Value.taskassigned}");
                                        Console.WriteLine("Do you have report to submit? Y/N");
                                        string inp = Console.ReadLine().ToUpper();
                                        if(inp=="Y")
                                        {
                                            Console.WriteLine("Enter the report you wish to submit.");
                                            worker.Value.submitwork(Console.ReadLine());
                                            Console.WriteLine("Successfully submitted report");
                                        }
                                        break;
                                    }
                            }

                        }
                        if (addedworker == true)
                        {
                            break;
                        }
                       
                            
                        
                        
                    }

                }
                else
                {
                    Console.WriteLine("ID does not match ");
                    Console.WriteLine("Do you wish to exit the system? Y/N");
                    string a = Console.ReadLine().ToUpper();
                    if (a == "Y")
                    {
                        stay = false;
                    }
                }
            }

            /*need to design a office mgmt. system , here  it consists of a three layred structure .means the super admin , admin , and the user.
             * The super admin has all the access to delete the user , create the user and all . But the admin can only have access to give task to the users.
             * user just have only on option that is to Log in and see the task he assigned and submit the detailed report of that particular work. 
             * Use file handling to store all the data
             */
        }
    }
}

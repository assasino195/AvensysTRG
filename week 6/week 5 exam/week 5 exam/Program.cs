using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_5_exam
{
    class Program
    {
        static void Main(string[] args)
        {
            ///Q1
            string filepath = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\week 5 exam\week 5 exam\q1\cusinfo.txt";
            List<customer> cuslst = new List<customer>();
            List<string> lines = File.ReadAllLines(filepath).ToList();
            double temp = 0;

            double temp1 = 0;
            foreach(var line in lines)
            {
                string[] entires = line.Split(',');
                try
                {
                    temp=double.Parse(entires[3]);
                    temp1 = double.Parse(entires[4]);
                }
                catch(Exception e)
                {
                    Console.WriteLine($"error found {e.Message}");
                }
                customer tempcus = new customer(entires[0], entires[1],temp,temp1);
                cuslst.Add(tempcus);
                //foreach (var cus in cuslst)
                //{
                //    Console.WriteLine($"{cus.name} {cus.id} {cus.chequeID} {cus.cash}");
                //}

            }
            bool stay = true;
            while (stay)
            {
               
               
                Console.WriteLine("Enter Name");
                            string name = Console.ReadLine();
                            Console.WriteLine("Enter ID");
                            string id = Console.ReadLine();
                Console.WriteLine($"1. Create new account\n2.Withdraw money\n3. Deposit Money\n4. Apply Loan\n0. Quit");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1"://new cus
                        {
                            
                            Console.WriteLine("Enter amount to deposit MAX 5k");
                            double.TryParse(Console.ReadLine(), out double cash);
                            if (cash > 5000)
                            {
                                Console.WriteLine("cannot deposit more than 5k");
                            }
                            else
                            {
                                bool accouthere = false;
                                foreach (var cus in cuslst)
                                {
                                    if (cus.id.Equals(id))
                                    {
                                        Console.WriteLine("you already have an account here");
                                        accouthere = true;
                                    }
                                   
                                }
                                if(accouthere==false)
                                {
                                    
                                        customer newcus = new customer(name, id, cash, 0);
                                        cuslst.Add(newcus);
                                        Console.WriteLine("ACCOUNT CREATED!");
                                        Console.WriteLine();
                                    
                                }
                            }
                            break;
                        }
                    case "2"://withdraw
                        {
                            Console.WriteLine("Please enter your cheque ID");
                            string cid = Console.ReadLine();
                            Console.WriteLine($"Please enter amount you wish to withdraw");
                            double.TryParse(Console.ReadLine(), out double with);
                            foreach(var cus in cuslst)
                            {
                                if(cus.id.Equals(id))
                                {
                                    cus.withdraw(with, cid);
                                }
                            }
                            break;
                        }
                    case "3"://deposit
                        {
                            Console.WriteLine("Please enter your cheque ID");
                            string cid = Console.ReadLine();
                            Console.WriteLine($"Please enter amount you wish to deposit");
                            double.TryParse(Console.ReadLine(), out double with);
                            foreach (var cus in cuslst)
                            {
                                if (cus.id.Equals(id))
                                {
                                    cus.deposit(with, cid);
                                }
                            }
                            break;
                        }
                    case "4"://appy loan
                        {
                            Console.WriteLine("Please enter your cheque ID");
                            string cid = Console.ReadLine();
                            Console.WriteLine($"Please enter amount you wish to loan for");
                            double.TryParse(Console.ReadLine(), out double amt);
                            foreach (var cus in cuslst)
                            {
                                if (cus.id.Equals(id))
                                {
                                    cus.applyforloan(amt, cid);
                                }
                            }
                            break;
                        }
                    case "0":
                        {
                            stay = false;
                            List<string> output = new List<string>();
                            foreach(var cus in cuslst)
                            {
                                output.Add($"{cus.name},{cus.id},{cus.chequeID},{cus.cash},{cus.loan}");
                            }
                            File.WriteAllLines(filepath, output);
                            Console.WriteLine("all entries updated");
                            break;
                        }
                }
                
            }
        }
    }
}

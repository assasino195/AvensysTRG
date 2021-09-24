using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSys
{
    class Program
    {
        static void print()
        {
            List<hospital> hsptlst = new List<hospital>();
            bool stay = true;

            Console.WriteLine("Welcome to S Hospital");
            Console.WriteLine();
            while (stay)
            {
                Console.WriteLine("Please Enter Your Name");
                string patname = Console.ReadLine();
                Console.WriteLine("Why are you here today?");
                Console.WriteLine("1. Emergency Svc");
                Console.WriteLine("2. Gynae");
                Console.WriteLine("3. Clinical Svc");
                Console.WriteLine("4. Othorpedic");
                Console.WriteLine("5. CheckOut");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            hospital h1 = new hospital(patname, input, 100);
                            hsptlst.Add(h1);
                            Console.WriteLine("Please head over to the emergency department");
                            break;
                        }
                    case "2":
                        {
                            hospital h1 = new hospital(patname, input, 50);
                            hsptlst.Add(h1);
                            Console.WriteLine("please head over to Gynae");
                            break;
                        }
                    case "3":
                        {
                            hospital h1 = new hospital(patname, input, 20);
                            hsptlst.Add(h1);
                            Console.WriteLine("please head over to Clinic");
                            break;
                        }
                    case "4":
                        {
                            hospital h1 = new hospital(patname, input, 80);
                            hsptlst.Add(h1);
                            Console.WriteLine("please head over to Ortho Department");
                            break;
                        }
                    case "5":
                        {
                            
                            foreach (hospital h in hsptlst)
                            {
                                if (patname == h.patientname)
                                {
                                    Console.WriteLine("Have you collected your medcine? Y/N");
                                    string k = Console.ReadLine().ToLower();
                                    if(k=="y")
                                    {
                                        Console.WriteLine(h.charges);
                                        Console.WriteLine("Pay by Cash?");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please go over and collect your medcine before coming back");
                                    }

                                    
                                }
                                else { Console.WriteLine("no such patient"); }
                            }
                            break;
                        }
                    default:
                        {
                            stay = false;
                            break;
                        }


                }
            }
        }
        static void Main(string[] args)
        {
            print();
            
        }
    }
}

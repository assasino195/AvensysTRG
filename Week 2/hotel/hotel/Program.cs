using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class Program
    {
        static void inithotel()
        {
            
        }

        static void display()
        {
            List<hotel> hotellst = new List<hotel>();
            hotel ht1 = new hotel("single deluxe room", 10, 0, false);
            hotel ht2 = new hotel("double deluxe room", 25, 0, false);
            hotel ht3 = new hotel("premium room", 50, 0, false);
            hotel ht4 = new hotel("suite", 100, 0, false);
            hotellst.Add(ht1);
            hotellst.Add(ht2);
            hotellst.Add(ht3);
            hotellst.Add(ht4);
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Welcome to hotel S ");
                Console.WriteLine("Room 1: Single deluxe room ($10/day)");
                Console.WriteLine("Room 2: double deluxe room($25/day)");
                Console.WriteLine("Room 3: Premium room ($50/day)");
                Console.WriteLine("Room 4: Suite room ($100/day)");
                Console.WriteLine("check out?");
                Console.WriteLine("6. Exit");
                string input = Console.ReadLine();
                Console.WriteLine();
                switch (input)
                {
                    case "1":
                        {
                            if (ht1.checkedin == false)
                            {


                                Console.WriteLine("How Many Days would you wish to stay?");
                                double days = double.Parse(Console.ReadLine());
                                ht1.stayingdays = days;
                                ht1.calculateroomrate();
                                ht1.checkedin = true;

                            }
                            break;
                        }
                    case "2":
                        {
                            if (ht2.checkedin == false)
                            {


                                Console.WriteLine("How Many Days would you wish to stay?");
                                double days = double.Parse(Console.ReadLine());
                                ht2.stayingdays = days;
                                ht2.calculateroomrate();
                                ht2.checkedin = true;
                            }
                            break;
                        }
                    case "3":
                        {
                            if (ht3.checkedin == false)
                            {


                                Console.WriteLine("How Many Days would you wish to stay?");
                                double days = double.Parse(Console.ReadLine());
                                ht3.stayingdays = days;
                                ht3.calculateroomrate();
                                ht3.checkedin = true;
                            }
                            break;
                        }
                    case "4":
                        {
                            if (ht4.checkedin == false)
                            {


                                Console.WriteLine("How Many Days would you wish to stay?");
                                double days = double.Parse(Console.ReadLine());
                                ht4.stayingdays = days;
                                ht4.calculateroomrate();
                                ht4.checkedin = true;
                            }
                            break;
                        }
                    case "5":
                        {
                            List<hotel> checkoutroomlst = new List<hotel>();
                            foreach (hotel h in hotellst)
                            {
                                if (h.checkedin == true)
                                {
                                    checkoutroomlst.Add(h);
                                    h.printall();
                                    Console.WriteLine("do you wish to check out this room? Y/N");
                                    string chckout = Console.ReadLine().ToLower();
                                    if(chckout=="y")
                                    {
                                        h.checkedin = false;
                                    }

                                }
                            }
                            //for (int i = 0; i < checkoutroomlst.Count; i++)
                            //{
                            //    Console.Write(checkoutroomlst[i]);
                            //}
                            Console.WriteLine();
                            
                           


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
            display();
            Console.ReadLine();
        }
    }
}

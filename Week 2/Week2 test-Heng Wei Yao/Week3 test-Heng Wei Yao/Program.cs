using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("Questions");
            Console.WriteLine("1: Q1 Rectangle Plot)");
            Console.WriteLine("2: Q2 ");
            Console.WriteLine("3: Q3");
            Console.WriteLine("4: Q4");
            Console.WriteLine("5: EXIT");

        }
        static void q1()
        {
            
           
            Console.WriteLine("Welcome to question 1");
            Console.WriteLine("Please enter the cost per Sq. foot");
            double costp = double.Parse(Console.ReadLine());
            
            bool stay = true;
            while(stay)
            {
                Console.WriteLine("Enter the Length of Rectangle");
                
                double legt = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter breadth of Rectangle");
                double breadt = double.Parse(Console.ReadLine());
                LandCalculator lc = new LandCalculator(costp,legt,breadt);
                Console.WriteLine($"Total cost = {lc.totalcost(costp,legt,breadt)}");
                Console.WriteLine();
                Console.WriteLine("Do you wish to exit? Q to exit");
                string loop = Console.ReadLine().ToLower();
                if(loop=="q")
                {
                    stay = false;
                }
                else
                {
                    stay = true;
                }
            }

        }
        static void q2()
        {
            
            Console.WriteLine("starting point value of X: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("starting point value of Y: ");
            double y = double.Parse(Console.ReadLine());
            

            Console.WriteLine("Ending point value of X: ");
            double x1 = double.Parse(Console.ReadLine());
            Console.WriteLine("Ending point value of Y: ");
            double y1 = double.Parse(Console.ReadLine());
            Line l1 = new Line(x, y,x1,y1);

            l1.display();
            l1.slope();
            Console.WriteLine();


        }
        static void q3()
        {
            Console.WriteLine("Welcome to Q3");
            
                Console.WriteLine("Enter distance of travel");
            double dist = double.Parse(Console.ReadLine());
            Console.WriteLine("Please pick the airline class you wish to travle by:\n 1. First Class \n 2.Second Class \n 3.Third Class");
            string input = Console.ReadLine();
            
           
                switch (input)
                {
                    case "1":
                        {
                            FirstClass fc = new FirstClass(dist);
                            Console.WriteLine($"Total cost of flight is{fc.costofflight()}");
                            break;
                        }
                    case "2":
                        {
                            SecondClass sc = new SecondClass(dist);
                            Console.WriteLine($"Total cost of flight is{sc.costofflight()}");
                            break;
                        }
                    case "3":
                        {
                            FirstClass fc = new FirstClass(dist);
                            Console.WriteLine($"Total cost of flight is{fc.costofflight()}");
                            break;
                        }
                    
                    default:
                        {
                            Console.WriteLine("Please enter valid option from 1 to 4");
                            break;
                        }
                }
            
        }
            static void Main(string[] args)
        {
            bool stay = true;
            while (stay)
            {
                menu();
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            q1();
                            break;
                        }
                    case 2:
                        {
                            q2();
                            break;

                        }
                    case 3:
                        {
                            q3();
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            stay = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid option no.");
                            break;
                        }
                }
            }
            Console.ReadLine();
        }
    }
}

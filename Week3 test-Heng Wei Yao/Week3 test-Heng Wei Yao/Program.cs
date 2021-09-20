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
            Console.WriteLine("1:)");
            Console.WriteLine("2:");
            Console.WriteLine("3:");
            Console.WriteLine("4:");
            Console.WriteLine("5: EXIT");

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
                            break;
                        }
                    case 2:
                        {
                            break;

                        }
                    case 3:
                        {
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
        }
    }
}

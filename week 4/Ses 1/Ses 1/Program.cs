using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ses_1
{
    class Program
    {
        private static int exceptionhandling(string a,string b)
        {
            while (true)//using exception with while loop makes the app not crash and it can keep running
            {
                try
                {
                    int input1 = Int32.Parse(a);
                    int input2 = Int32.Parse(b);
                        Console.WriteLine($"A / B = {input1/input2}");
                    //int a = Int32.Parse(Console.ReadLine());
                    //int res = a / 2;
                    //Console.WriteLine($"Input divided by 0 ={res}");
                    //var b = Console.ReadLine();
                    //var inta = Int32.Parse(b);
                    //int[] arr = new int[5] { 1, 2, 3, 4, 5 }; 
                    //for(int i=0;i<arr.Length;i++)
                    //{
                    //    Console.WriteLine(arr[i]);
                    //}

                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Eception raised {ex}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"FORMAT Eception raised {ex}");
                }
                catch (NullReferenceException ex)
                {
                    Console.WriteLine($"Null Eception raised {ex}");
                }
                catch(IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Indexer out of range exception raised {ex}");
                }
                catch(InvalidCastException ex)
                {
                    Console.WriteLine($"Invalid cast detected {ex}");
                }
                catch (Exception ex)//catches all exception but its not recommended this general/generic catch should always be at the btm or there will be an error
                {
                    Console.WriteLine($"Exception deteched {ex}");
                }
                finally//after all the try catch this will alwaus run
                {
                    Console.WriteLine("Finally");
                }
            }
        }
        static void Main(string[] args)
        {
            string input1 = Console.ReadLine();
            string input2 = Console.ReadLine();
            exceptionhandling(input1,input2);
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4WeeklyTest
{
    class Program
    {
        static void Main(string[] args)
        {
            manu obj = new manu();
            //Console.WriteLine("Enter first input");
            //object a = Console.ReadLine();
            //Console.WriteLine("Enter 2nd input");
            //object b = Console.ReadLine();
            List<string> lst1 = new List<string>();
            List<string> lst2 = new List<string>();
            lst1.Add("50");
            lst1.Add("20");
            lst2.Add("10");
           // Console.WriteLine(obj.Add(a, b));
            Console.WriteLine(obj.Add(lst1,lst2));
            lst1.AddRange(lst2);
            Console.ReadLine();
        }
    }
}

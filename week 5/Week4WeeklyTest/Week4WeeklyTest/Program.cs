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
            Console.WriteLine("Enter first input");
            object a = Console.ReadLine();
            Console.WriteLine("Enter 2nd input");
            object b = Console.ReadLine();
            Console.WriteLine(obj.Add(a, b));
            Console.ReadLine();
        }
    }
}

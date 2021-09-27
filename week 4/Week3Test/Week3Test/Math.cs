using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    public delegate void EventHandlerOperation(int a, int b);
    public class Math
    {
        public static void Add(int x, int y)
        {
            Console.WriteLine("Addition: " + (x + y));
        }
        public static void Min(int x, int y)
        {
            Console.WriteLine("Subtraction: " + (x - y));
        }
        public void Times(int x, int y)
        {
            Console.WriteLine("Multiplication: " + (x * y));
        }
        public void Div(int x, int y)
        {
            Console.WriteLine("Division: " + (x / y));
        }

       
    }
}

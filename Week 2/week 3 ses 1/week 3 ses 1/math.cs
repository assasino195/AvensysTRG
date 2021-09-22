using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    delegate void delexample(int i, int j);
    delegate void display();
    class Addition
    {
        public void add(int a, int b)
        {
            Console.WriteLine($"Addition of {a} + {b} = {a + b}"); ;
        }
        
        public void print()
        {
            Console.WriteLine($"Addition of");
        }

    }
    class subtraction
    {
        public void sub(int a, int b)
        {
            Console.WriteLine($"subtraction of {a} + {b} = {a - b}"); ;
        }
        public void print()
        {
            Console.WriteLine($"subtraction");
        }
    }
    class Multiply
    {
        public void multi(int a, int b)
        {
            Console.WriteLine($"Multiplication of {a} * {b} = {a * b}");
        }
    }
}

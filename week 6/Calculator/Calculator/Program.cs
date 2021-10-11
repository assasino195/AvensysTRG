using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter first number of 1st complex");
            string a = Console.ReadLine();
            Console.WriteLine("enter 2nd number of 1st complex");
            Complex first = new Complex(double.Parse( a),double.Parse(Console.ReadLine()));
            Console.WriteLine("enter first number of 2nd complex");
            string b = Console.ReadLine();
            Console.WriteLine("enter 2nd number of 2nd complex");
            Complex second = new Complex(double.Parse(b), double.Parse(Console.ReadLine()));
            class1 cs = new class1();
            Console.WriteLine(cs.add(first, second));
            Console.WriteLine((cs.sub(first,second)));
            Console.WriteLine(cs.divi(first,second));
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Class1<int> c1 = new Class1<int>(10,20,30);
            Console.WriteLine("IF INT");
            Console.WriteLine(c1.validate()) ;
            Console.WriteLine(c1.inspect());
            Class1<string> c2 = new Class1<string>("hello","Bye","Gooday");
            Console.WriteLine("IF STRING");
            Console.WriteLine(c2.validate());
            Console.WriteLine(c2.inspect());
            Console.ReadLine();

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;


namespace ComplexClass
{
    class Program
    {
        static void Main(string[] args)
        {
            complexExamples();
            BigintegerExample();

            Console.ReadLine();
        }

        private static void BigintegerExample()
        {
            BigInteger biginteger = new BigInteger(17583.4385);
            BigInteger biginteger2 = new BigInteger(200434.9392);
            Console.WriteLine("first big integer {0}", biginteger);
            Console.WriteLine("2nd big integer {0}", biginteger2);
            string str = "4343534324.342432";
            BigInteger biginteger3 = BigInteger.Parse(str);
            Console.WriteLine("String: {0}", str);
            Console.WriteLine("Value from stirng {0}", biginteger3);
            Console.WriteLine($"Power of 3, big integer{BigInteger.Pow(biginteger3, 3)}");
            Console.WriteLine($"Add in big integer {BigInteger.Add(biginteger, biginteger2)}");
        }

        private static void complexExamples()
        {
            Complex complex1 = new Complex(12, 6);
            Console.WriteLine($"First complex number is: {complex1}");
            Complex complex2 = new Complex(4, 8);
            Console.WriteLine($"2nd complex number is {complex2}");
            Console.WriteLine($"Sum of both complex number is: {complex1 + complex2}");
        }
    }
}

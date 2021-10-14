using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reverse_a_string_without_bcl
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter string");
            string a = Console.ReadLine();
            for(int i=a.Length-1;i>=0;i--)
            {
                Console.Write(a[i]);
            }
            Console.ReadLine();
        }
    }
}

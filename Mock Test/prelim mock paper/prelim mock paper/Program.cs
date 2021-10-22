using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prelim_mock_paper
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter 1st integer");
                int a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("enter 2nd integer");
                int b = Int32.Parse(Console.ReadLine());
                int temp0, temp1, temp2, gcf, lcm;
                temp1 = a;
                temp2 = b;
                while (temp2 != 0)
                {

                    temp0 = temp2;
                    temp2 = temp1 % temp2;
                    temp1 = temp0;
                }
                gcf = temp1;
                lcm = ((a * b) / gcf);
                Console.WriteLine($"GCF of {a} & {b} is: {gcf}");
                Console.WriteLine($"LCM of {a} & {b} is {lcm}");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }
    }
}

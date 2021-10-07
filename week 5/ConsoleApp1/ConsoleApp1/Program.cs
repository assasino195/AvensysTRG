using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = "I love to code in c#";
            //string[] temp = a.Split(' ');
            //string output = string.Empty;
            //foreach(string o in temp.Reverse())
            //{
            //    Console.Write(char.ToUpper(o[0])+o.Substring(1).ToLower()+" ");
            //}

            //Console.WriteLine(output);

            //  Console.WriteLine(char.ToUpper(output[0]) + output.Substring(1).ToLower());
            Console.WriteLine("Enter date time");
            bool pass= DateTime.TryParse(Console.ReadLine(), out DateTime o);
            if (pass)
            {
                DateTime now = DateTime.Now;
                TimeSpan t = now - o;
                Console.WriteLine(t);
            }
            else
            {
                Console.WriteLine("invalid");
            }
            Console.ReadLine();
        }
    }
}

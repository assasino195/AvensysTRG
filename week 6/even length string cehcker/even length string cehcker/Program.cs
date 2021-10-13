using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace even_length_string_cehcker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter string");
            string str = Console.ReadLine();
            int maxlength = str.Length;
            int chunkSize = maxlength / 2;
           
            string a = string.Empty;
            string b = string.Empty;
            //a = str.Substring(0, chunkSize);
            //b = str.Substring(chunkSize,5);
            string str1 = str.Substring(0, str.Length / 2).ToLower();
            string str2 = str.Substring(str.Length / 2).ToLower();
            if(str1.Equals(str2))
            {
                Console.WriteLine("MIRROR");
            }
            else
            {
                Console.WriteLine("Not mirrored");
            }
           
            Console.ReadLine();
           
          
        }
        static IEnumerable<string> Split(string str, int chunkSize)
        {
            return Enumerable.Range(0, str.Length / chunkSize)
                .Select(i => str.Substring(i * chunkSize, chunkSize));
        }
    }
}

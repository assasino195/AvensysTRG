using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reverse_number_without_converting_to_string
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(reverseNumber(n));
            //int n = 12345;
            int left = n;
            int rev = 0;
            while (Convert.ToBoolean(left)) // instead of left>0 , to reverse signed numbers as well
            {
                int r = left % 10;
                rev = rev * 10 + r;
                left = left / 10;  //left = Math.floor(left / 10); 
            }

            Console.WriteLine(rev);
            Console.ReadLine();
        }
        public static int reverseNumber(int Number)
        {
            int ReverseNumber = 0;
            while (Number > 0)
            {
                ReverseNumber = (ReverseNumber * 10) + (Number % 10);
                Number = Number / 10;
            }
            return ReverseNumber;
        }
    }
}

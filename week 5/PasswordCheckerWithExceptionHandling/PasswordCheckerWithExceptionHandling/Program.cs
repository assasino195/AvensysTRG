using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCheckerWithExceptionHandling
{
    class Program
    {
       
        static void Main(string[] args)
        {


            //int smallletter = 0;
            //int bigletter = 0;
            //int valid = 0;
            string input = string.Empty;
            
           
           
            
            try
            {
                Console.WriteLine("Please create your password");
                object input1 = Console.ReadLine();
                input = input1.ToString();
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Null Eception raised {ex.Message}");
            }
            catch (OverflowException ex)
            {
                Console.WriteLine($"Over flowed {ex.Message}");
            }

            publisher p = new publisher();
            p.send += P_send;
            p.getinput(input);
           
           
            Console.ReadLine();

        }

        private static void P_send(string s)
        {
            Console.WriteLine(s);
        }
    }
}

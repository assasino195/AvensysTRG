using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCheckerWithExceptionHandling
{
    class Program
    {
        public static bool Contains(string target, string list)
        {
            return target.IndexOfAny(list.ToCharArray()) != -1;
        }
        private static bool CheckInvalidInput(string stringToCheck, IEnumerable<char> allowedChars)
        {
            return stringToCheck.All(allowedChars.Contains);
        }
        static void Main(string[] args)
        {


            //int smallletter = 0;
            //int bigletter = 0;
            //int valid = 0;
            string input = string.Empty;
            char temp = ' ';
            //char temp2 = ' ';
            int count = 0;
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = uppercase.ToLower();
            string digits = "123456789";
            string special = " ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; ";
            var allowedchars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+=-[]{}";
           
           
            
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



            bool okay = CheckInvalidInput(input, allowedchars);
            if (okay == false)
            {
                Console.WriteLine("Your password contained characters that are not allowed");
            }
            if (Contains(input, lowercase) && Contains(input, uppercase) && Contains(input, digits))
            {

            }
            else
            {
                okay = false;
            }
            foreach (char a in input)
            {
                if (temp == a)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count > 1)
                {
                    okay = false;
                    Console.WriteLine("Passoword contained multiple iteration of same character eg. aaa max=2");
                }
                temp = a;



            }


            if (okay == true)
            {
                Console.WriteLine("password accepted");

            }
            else
            {
                Console.WriteLine("password not accepted");
            }
            Console.WriteLine();
            Console.ReadLine();

        }
    }
}

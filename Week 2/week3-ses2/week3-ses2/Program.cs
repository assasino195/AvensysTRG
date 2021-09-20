using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_pretest_practice
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("CALCULATOR");
            Console.WriteLine("1 Addition:");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Division");
            Console.WriteLine("4: Multiplication");
            Console.WriteLine("5: Modulation");
            Console.WriteLine("6: EXIT");

        }
        static void calculatorapp()
        {
            calculatorclass cal = new calculatorclass();

            int tempA;
            int tempB;


            bool stay = true;
            while (stay)
            {
                menu();
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1: //ADD
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} + {tempB} = {cal.add(tempA, tempB)}");

                            break;
                        }
                    case 2: //subtract
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} - {tempB} = {cal.subtract(tempA, tempB)}");
                            break;

                        }
                    case 3:// divide
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} / {tempB} = {cal.divide(tempA, tempB)}");
                            break;
                        }
                    case 4://multiply
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} * {tempB} = {cal.multiply(tempA, tempB)}");
                            break;
                        }
                    case 5://modulate
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} % {tempB} = {cal.modulus(tempA, tempB)}");
                            break;
                        }
                    case 6:
                        {
                            stay = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid option no.");
                            break;
                        }
                }
            }
        }
        public static bool Contains(string target, string list)
        {
            return target.IndexOfAny(list.ToCharArray()) != -1;
        }
        private static bool CheckInvalidInput(string stringToCheck, IEnumerable<char> allowedChars)
        {
            return stringToCheck.All(allowedChars.Contains);
        }
        static void passwordcheck()
        {

            //int smallletter = 0;
            //int bigletter = 0;
            //int valid = 0;

            char temp = ' ';
            //char temp2 = ' ';
            int count = 0;
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = uppercase.ToLower();
            string digits = "123456789";
            string special = " ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; ";
            var allowedchars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+=-[]{}";

            Console.WriteLine("Please create your password");
            string input = Console.ReadLine();

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

            //if (Contains(input, lowercase) && Contains(input,uppercase) && Contains(input,digits) )
            //    {
            //        valid = 1;
            //    }
            //if(Contains(input,special))
            //{
            //    valid = 1;
            //}
            //else

            //if (valid == 1)
            //{
            //    Console.WriteLine("password accepted");

            //}
            //else
            //{
            //    Console.WriteLine("password denied");
            //}
            //if(5 < input.Length && 25>input.Length)
            //{
            //    foreach(char a in input)
            //    {

            //        if(a>='a' && a<='z' )
            //        {


            //            if (a >= 'A' && a <= 'Z')
            //            {
            //                bigletter++;
            //                if (a >= '0' && a <= '9')
            //                {

            //                    okay = true;
            //                    if (a == temp && input[a + 1] == temp)
            //                    {
            //                        okay = false;
            //                        Console.WriteLine("iteration of 3 characters");
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        okay = true;
            //                        break;
            //                    }

            //                }
            //            }
            //        }

            //    }

            //}
            //    if (okay == false)
            //    {
            //        Console.WriteLine("please re-enter your password");
            //    }
            //    else
            //    {
            //        Console.WriteLine("password accepted");
            //    }
            //    Console.WriteLine($"small letter{smallletter}: Big letter{bigletter}");
        }
        static void Main(string[] args)
        {
            passwordcheck();
            Console.ReadLine();
            /*write a program to find a prime number between 1 to 100 , then reverse the number if the reverse number is also a prime one , then store the number

            find out the total number of days and sessions you have joined till now then convert the total time into seconds.
            Using boxing and unboxing concept

            5.write a program  that determines whether a string is a valid hex code .A hex code must begin with a pound key # and is exactly 6 characters in length. 
            Each character must be a digit from 0-9 or an alphabetic character from A-F. All alphabetic characters may be uppercase or lowercase.
            (use inheritance concept)
            */
        }
    }
}

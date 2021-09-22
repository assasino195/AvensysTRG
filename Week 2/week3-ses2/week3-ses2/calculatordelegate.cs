using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_ses2
{
    delegate void delcal(int i, int j);
    class program
    {
        class Addition
        {
            public void addy(int a, int b)
            {
                Console.WriteLine($"Addition of {a} + {b} = {a + b}"); ;
            }
        }
        class subtraction
        {
            public void subyint(int a, int b)
            {
                Console.WriteLine($"Addition of {a} - {b} = {a - b}"); ;
            }
        }
        class multiplication
        {
            public void multy(int a, int b)
            {
                Console.WriteLine($"Addition of {a} * {b} = {a * b}"); ;
            }
        }
        class division
        {
            public void diviy(int a, int b)
            {
                Console.WriteLine($"Addition of {a} / {b} = {a / b}"); ;
            }
        }
        class modulus
        {
            public void mody(int a, int b)
            {
                Console.WriteLine($"Addition of {a} %{b} = {a % b}"); ;
            }
        }
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
        static void delcalulator()
        {
            bool stay = true;
            while (stay)
            {

                menu();
                string input = Console.ReadLine();
                Console.WriteLine("Enter First Digit");
                var a = Int32.Parse(Console.ReadLine());
                Console.WriteLine("Enter Second Digit");
                var b = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case "1"://add
                        {

                            Addition add = new Addition();
                            delcal del1 = new delcal(add.addy);
                            operation.performoperations(a, b, del1);

                            break;
                        }
                    case "2"://sub
                        {
                            subtraction sub = new subtraction();
                            delcal del2 = new delcal(sub.subyint);
                            operation.performoperations(a, b, del2);
                            break;
                        }
                    case "3"://divi
                        {
                            division divi = new division();
                            delcal delcal3 = new delcal(divi.diviy);
                            operation.performoperations(a, b, delcal3);
                            break;
                        }
                    case "4"://multi
                        {
                            multiplication multi = new multiplication();
                            delcal del4 = new delcal(multi.multy);
                            operation.performoperations(a, b, del4);
                            break;
                        }
                    case "5"://mod
                        {
                            modulus mod = new modulus();
                            delcal del5 = new delcal(mod.mody);
                            operation.performoperations(a, b, del5);
                            break;
                        }
                    case "6"://exit
                        {
                            stay = false;
                            break;
                        }
                }

            }
        }
        class hcf
        {
            public void fhcf(int a,int b)
            {

            }
        }
        static void Main(string[] args)
        {
            //delcalulator();

            Console.ReadLine();
        }
    }
}

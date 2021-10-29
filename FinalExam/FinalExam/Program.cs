using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter input string");
            string input = Console.ReadLine();

            string[] split = input.Split(' ');
            Console.WriteLine("1.Turn all to camel casing\n2.Return all vowels in the string");
            string userinput = Console.ReadLine();
            if(userinput=="1")
            {
                foreach (string a in split)
                {

                    Console.Write(char.ToUpper(a[0]));
                    Console.Write(a.Substring(1));
                    Console.Write(' ');

                }
            }
            else if(userinput=="2")
            {
                int total = 0;
                char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };
                foreach (string a in split)
                {
                    foreach(char letter in a)
                    {
                        if(vowels.Contains(char.ToLower(letter)))
                        {
                            Console.Write(letter);
                            total++;
                        }
                        //else
                        //{
                        //    Console.Write(' ');
                        //}
                    }
                    Console.Write(' ');

                }
                Console.WriteLine("Total number of vowels is: "+total);
            }
            //The name is Cuttack which is the capital state of Odisha
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    class Program
    {
        static void Main(string[] args)
        {
            //This is it...
            Console.WriteLine(  "Enter string");
            string input = Console.ReadLine();
            //string[] split = input.Split();
            char[] punctuations = new char[] { '!', '.', ',', ':', ';', '@', '#', '$' };
            Stack<char> charstack = new Stack<char>();
            foreach(char a in input)
            {
                if(punctuations.Contains(a)||a.Equals(' '))
                {
                    if (charstack.Count > 0)
                    {
                        for (int i = charstack.Count; i > 0; i--)
                        {
                            Console.Write(charstack.Pop());

                        }
                    }
                    Console.Write(a);
                   
                }
                else
                {
                    charstack.Push(a);
                }
            }
            //foreach(string a in split)
            //{
            //    for (int i = a.Length-1; i >= 0; i--)
            //    {
            //        if (!punctuations.Contains(a[i]))
            //        {
            //            Console.Write(a[i]);
            //        }
            //        else
            //        {
            //            charstack.Push(a[i]);
            //        }
            //    }
            //  for(int i=charstack.Count;i>0;i--)
            //    {
            //        Console.Write(charstack.Pop());
            //    }
            //    Console.Write(' ');
            //}

            Console.ReadLine();
        }
    }
}

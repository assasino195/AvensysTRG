using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter input string");
            string input = Console.ReadLine();
           
            string[] split = input.Split(' ');
            foreach(string a in split)
            {
                Dictionary<char, int> chardic = new Dictionary<char, int>();
                foreach(char letter in a)
                {
                    if(!chardic.ContainsKey(letter))
                    {
                        Console.Write(letter);
                        chardic.Add(letter, 1);
                    }
                    
                }
                Console.Write(' ');

            }
         //The name is Cuttack which is the capital state of Odisha
            Console.ReadLine();
        }
    }
}

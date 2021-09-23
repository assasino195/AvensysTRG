using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace string_split_print_Delegate_events
{
    class Program
    {
        static void Main(string[] args)
        {
            subscriber sub = new subscriber();
            publisher pub = new publisher();
            sub.subscribetoevent(pub);
            int count = 0;
            Console.WriteLine("enter your input string");
            string[] input = (Console.ReadLine()).Split(' ');
            foreach(string a in input)
            {
                count++;
            }
            pub.getinput(input, count);
            Console.ReadLine();

        }
    }
}

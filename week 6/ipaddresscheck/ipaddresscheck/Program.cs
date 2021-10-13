using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipaddresscheck
{
    class Program
    {
        static void Main(string[] args)
        {
            string ints = "1234567890";
            Console.WriteLine("Enter IP Address");
            string str = Console.ReadLine();
            string[] splitted = str.Split('.') ;
            bool ip = false;
            foreach(string a in splitted)
            {
                int count = 0;
                bool allint = true;
                foreach(char b in a)
                {

                    if (allint)
                    {
                        count++;
                        if (b == '1' || b == '2' || b == '3' || b == '4' || b == '5' || b == '6' || b == '7' || b == '8' || b == '9' || b == '0')
                        {
                            allint = true;
                        }
                        else
                        {
                            allint = false;
                            break;

                        }
                    }
                    else
                    {
                        Console.WriteLine("Not valid ip");
                        break;
                    }
                }
                if(allint ==false)
                {
                    ip = false;
                    break;
                }

                if(count<4)
                {
                    ip = true;
                }
                else
                {
                    break;
                    ip = false;
                    Console.WriteLine("Not valid IP");
                }
            }
            if(ip)
            {
                Console.WriteLine("REAL IP");
            }
            else
            {
                Console.WriteLine("FAKE IP");
            }
            Console.ReadLine();
        }
    }
}

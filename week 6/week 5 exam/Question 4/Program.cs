using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Question_4
{
    class class1
    {
        private List<string> hexlst;
        private List<int> intlst;
        public List<string> hex
        {
            get
            {
                if (hexlst == null)
                {
                    hexlst = new List<string>();
                }
                return hexlst;
            }
            set
            {
                hexlst = value;
            }
        }
        public List<int> intt
        {
            get
            {
                if (intlst == null)
                {
                    intlst = new List<int>();
                }
                return intlst;
            }
            set
            {
                intlst = value;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            class1 c1 = new class1();
           
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("1.Convert hexdecimal");
                Console.WriteLine("2.Amount of prime numbers");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter hexdecimal:");
                            string hexdecimal = Console.ReadLine();
                            c1.hex.Add(hexdecimal);
                            break;
                        }
                    case "2":
                        {
                            foreach (var hex in c1.hex)
                            {
                                int intValue = int.Parse(hex);
                                c1.intt.Add(intValue);
                            }
                            foreach (var prime in c1.intt)
                            {
                                Console.WriteLine(IsPrime(prime));
                                if (IsPrime(prime) == true)
                                {
                                    count++;
                                }
                            }
                            Console.WriteLine($"Total prime numbers: {count}");
                            break;
                        }
                }
                if (input == "1")
                {
                    
                }
                if (input == "2")
                {
                   
                }

            }
        }
        public static bool IsPrime(int k)
        {
            bool prime = true;
            for (int i = 2; i < k / 2; i++)
            {
                if (k % i == 0)
                {
                    prime = false;
                    break;
                }
            }
            return prime;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "Blood Type A: 0";
            //publisher bloodA = new publisher("A", 0);
            //publisher bloodB = new publisher("B", 0);
            //publisher bloodAB = new publisher("AB", 0);
            publisher pub = new publisher();
            subscriber sub = new subscriber();
            sub.subscribetoevent(pub);
            //sub.subscribetoevent(bloodB);
            //sub.subscribetoevent(bloodAB);
            bool stay = true;
            int count = 0;
            while (stay)
            {
                Console.WriteLine("1. Add Blood");
                Console.WriteLine("2. Display list of blood");

                
                Console.WriteLine("3. exit");
                string inputt = Console.ReadLine();
                switch(inputt)
                {
                    case "1":
                        {
                            
                            Console.WriteLine("enter name of blood");
                            string input = Console.ReadLine().ToUpper();
                            Console.WriteLine("enter count of blood");
                            int c = Int32.Parse(Console.ReadLine());
                            //if(input=="A")
                            //{
                            //    bloodA.getinput(input, c);
                            //    string add2list = $"Blood Type {input}: {c}";
                            //}
                            pub.getinput(input, c);
                            
                            count++;

                            break;
                        }
                    case "2":
                        {

                            for (int i = 0; i < count; i++)
                            {

                                Console.WriteLine((i + 1) + ": " + pub[i]);
                            }
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            stay = false;
                            break;
                        }
                }
                
                
                
            }
            
            Console.ReadKey();
        }
    }
}

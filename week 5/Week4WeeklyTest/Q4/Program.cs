using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace Q4
{
    class Program
    {
        public static void menu()
        {
            Console.WriteLine("1. Create new thread");
            Console.WriteLine("2. Destroy thread");
            Console.WriteLine("3.Change to synchro");
            Console.WriteLine("4. sleep for amt of seconds");
        }
        public static void display(int input1,int input2)
        {

           // Console.WriteLine($"{input1} + {input2} = {input1 + input2}");



            //program p = new program();
            //Console.WriteLine(p.add(input1,input2));
            //Console.WriteLine(p.subtract(input1,input2));
            //Console.WriteLine((p.divide(input1,input2)));
            //Console.WriteLine((p.modulus(input1,input2)));
            //Console.WriteLine(p.power(input1,input2));



        }
        static void Main(string[] args)
        {
            program p = new program();
            Console.WriteLine("Enter first digit");
            object a = Console.ReadLine();
            Console.WriteLine("enter second digit");
            object b = Console.ReadLine();
            int input1 = 0;
            int input2 = 0;
            try
            {
                input1 = int.Parse((string)(a));
                input2 = int.Parse((string)(b));
                Thread t = new Thread(() => { display(input1, input2); });
                Thread t1 = new Thread(() => { p.add(input1, input2); });
                Thread t2 = new Thread(() => { p.subtract(input1, input2); });
                Thread t3 = new Thread(() => { p.divide(input1, input2); });
                Thread t4 = new Thread(() => { p.modulus(input1, input2); });
                Thread t5 = new Thread(() => { p.power(input1, input2); });

                t1.Start();
                t2.Start();
                t3.Start();
                t4.Start();
                t5.Start();

            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception caught: {e.Message}");
            }
            
           
            
            //t.Start();
            Console.ReadLine();


            //    int lstcount = 0;
            //    int count = 0;
            //    bool stay = true;
            //    List<Thread> threads = new List<Thread>();

            //    //List<int> lst = new List<int>();
            //    MyList<int> lst = new MyList<int>();


            //    while (stay)
            //    {

            //        menu();
            //        string input = Console.ReadLine();
            //        switch(input)
            //        {
            //            case "1":
            //                {

            //                    //Thread t = new Thread(() => { display(); });
            //                    ParameterizedThreadStart param = new ParameterizedThreadStart(display);
            //                    Thread tp = new Thread(param);
            //                    lst.Add(param);
            //                    tp.Start();
            //                    //lst.Add(count);
            //                    //    count++;
            //                    //    lstcount++;

            //                    break;
            //                }
            //            case "2":
            //                {



            //                    break;
            //                }
            //            case "3":
            //                {

            //                    break;
            //                }
            //            case "4":
            //                {
            //                    break;
            //                }
            //           default:
            //                {
            //                    break;
            //                }
            //        }
            //    }
            //}

        }
    }
}

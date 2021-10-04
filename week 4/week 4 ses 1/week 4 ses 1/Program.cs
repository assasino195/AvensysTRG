using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace week_4_ses_1
{
    class Program
    {
       
        public static void calculateint()
        {
            publiseher p = new publiseher();

            Console.WriteLine("interest");
            double interest = double.Parse(Console.ReadLine());
            Console.WriteLine("months");
            double year = double.Parse(Console.ReadLine());
            Console.WriteLine("amt");
            double amt = double.Parse(Console.ReadLine());
            p.numbermodifiedevent += P_numbermodifiedevent;
            p.calculateint(amt, interest, year);
        }
        public static void FUNCC()
        {
            Funcc fc = new Funcc();
            fc.practice();
            //fc.print();
        }
        
        public static void swap<T>(ref T a , ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
        public static void GenericMethodT()
        {
            int a = 3;
            int b = 5;
            Console.WriteLine($"A: {a}  B:{b}");
            swap<int>(ref a, ref b);
            Console.WriteLine($"After {a}  {b}");

            double a1 = 1.5;
            double a2 = 3.3;
            Console.WriteLine($"A1: {a1}   A2{a2}");
            swap<double>(ref a1,ref a2);
            Console.WriteLine($"After {a1}  {a2}");

            string one = "Hello";
            string two = "Bye";
            Console.WriteLine($"A1: {one}   A2{two}");
            swap<string>(ref one, ref two);
            Console.WriteLine($"After {one}  {two}");
        }
        public class Device<T> //where T:struct
        {
            public T name { get; set; }
            public T caategory { get; set; }
        }
        public interface Imygenericinterface<T>
        {
            void dosmth(T a, T b);
            void dosmthelse(T a1, T b1);
        }
        class mygnericclass<T> : Imygenericinterface<T>
        {
            public void dosmth(T a, T b)
            {
                throw new NotImplementedException();
            }

            public void dosmthelse(T a1, T b1)
            {
                throw new NotImplementedException();
            }
        }
        public static void genericinterfaceinherit()
        {
          
            mygnericclass<int> genericint = new mygnericclass<int>();
                
        }
        public static void GenricClass()
        {
            Device<int> intobj = new Device<int>();
            Device<float> floatobj = new Device<float>();
            Device<string> stringobj = new Device<string>();
            intobj.name = 1;
            intobj.caategory = 10;

            floatobj.name = 0.5f;
            floatobj.caategory = 10.5f;

            stringobj.name = "hello";
            stringobj.caategory = "Words";

            Console.WriteLine($"Name of int {intobj.name}  Category of int:{intobj.caategory}");
            Console.WriteLine($"Name of float {floatobj.name}  category of float:{floatobj.caategory}");        
        }
        public class genericques<T>
        {
            public T[] input = new T[5];
            public T name { get; set; }
            public T this[int index]
            {
                get { return input[index]; }
                set { input[index] = value; }
            }
        }
        public static void classques()
        {
            genericques<string> a = new genericques<string>();
            genericques<int> b = new genericques<int>();
             a.input =new string[]{ "hi", "lol", "hehe","kek","Monka"};
            a.name = "Words";
            foreach(string i in a.input)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine(a.name);
            Console.WriteLine(a[2]);
            Console.WriteLine();
            b.input = new int[] { 1, 2, 3, 4, 5 };
            foreach(int o in b.input)
            {
                Console.WriteLine(o);
            }

            
            b.name = 15;
            Console.WriteLine(b.name);
            Console.WriteLine(b[4]);
        }
        public static void threadstes()
        {
            Thread t = new Thread(() => { string v = "Starting Thread"; });
            Thread t1 = new Thread(() => { string v = "Starting Thread again"; });
            t.Start();
            Thread.Sleep(1000);
            t1.Start();

        }
        static void Main(string[] args)
        {

            bool stay = true;
            while(stay)
            {
                Console.WriteLine("1.Simple Interest\n2.Func");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        {
                            calculateint();
                            break;
                        }
                    case "2":
                        {
                            FUNCC();
                            break;
                        }
                    case "3":
                        {
                            GenericMethodT();
                            break;
                        }
                    case "4":
                        {
                            GenricClass();
                            break;
                        }
                    case "5":
                        {
                            classques();
                            break;
                        }
                    case "6":
                        {
                            threadstes();
                            Thread.Sleep(1000);
                            for (int i=0;i<50;i++)
                            {
                                Console.WriteLine( "Hello world");
                            }
                            
                            break;
                        }
                }
            }
            Console.ReadLine();


        }

        private static void P_numbermodifiedevent(object sender, inteventargs e)
        {
            Console.WriteLine($"Calculated number is {e.input1}");
        }
    }
    
}

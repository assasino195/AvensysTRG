using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_4_ses_1
{
    class Funcc
    {
        public void print()
        {
            Func<int, int,int> func = sum;
            Func<int> func1 = returnconstant;
            Func<int, int> func2 = (a) => { return a + 100; };
            Console.WriteLine(func(10,20));
            Console.WriteLine(func1);
            Console.WriteLine(func2(10));
            Action act = () => Console.WriteLine("EMPTY ACCTION");
            Action<int, int> act1 = (a, b) =>
               {
                   Console.WriteLine("action 1: ", a * b);
               };
            Predicate<string> predicate = (str) =>  //predefined bool so only need to pass  value
            // can pass anything inside eg, string int double etc.. only takes 1 parameter
              {
                  if (str.Length > 10)
                  {
                      return true;
                  }
                  else return false;
              };
            Console.WriteLine(predicate("STR"));
            Console.WriteLine(predicate("THIS IS STRINGGGGGGG"));

        }

        public int sum(int a, int b)
        {
            return a + b;
        }
        public int returnconstant()
        {
            return 100;
        }
        public double square(double a)
        {
            
            return Math.Sqrt(a);
        }
        public void practice()
        {
            Func<double,double> funcprac = square;
            Action<int> actprac = (a) =>
               {
                   if (a == 100)
                   {
                       Console.WriteLine("ITS A SQUARE");
                   }
               };

            
            Predicate<int> predprac = (test) =>
              {
                  if (test == 100)
                  {
                      return true;
                  }
                  else return false;
              };
            Console.Write("Square root of:");
            double lol = double.Parse(Console.ReadLine());
            Console.WriteLine("is "+ funcprac(lol));
            Console.WriteLine("enter number for perfect square?");
            int lolol = int.Parse(Console.ReadLine());
            actprac(lolol);
            Console.WriteLine("Pred test input number");
            int lololol = int.Parse(Console.ReadLine());
            Console.WriteLine(predprac(lololol)); 

        }
    }
}
   

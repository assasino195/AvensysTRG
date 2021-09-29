using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week4_ses2
{
    class samevaluexception : Exception
    {
        public samevaluexception() { Console.WriteLine(base.Message); }
        public samevaluexception(string valueexcpetion) : base(string.Format("Enter two different values" + valueexcpetion))
        {

        }
    }
    class q10eventargs
    {
       // public int a1 { get;private set; }
        public int c { get; private set; }
        int a1 = 0;
        int a2 = 0;
        public q10eventargs(object a, object b)
        {

            try
            {
               a1 = int.Parse(a.ToString());
                a2 = int.Parse(b.ToString());
                if (a1 != a2)
                {
                    c = a1 + a2 ;
                    //Console.WriteLine(c);
                }
                else
                {
                    throw (new samevaluexception($" instead of {a1} & {a2}"));
                }


            }
            catch (samevaluexception e)
            {
                Console.WriteLine(e.Message.ToString());


            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Argument null caught: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Format exception caught: {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Over flow exception caught: {e.Message}");
            }
            catch(StackOverflowException e)
            {
                Console.WriteLine($"Caught stack over flow exception; {e.Message}");
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
namespace Week3Test
{
    class timer
    {

        private int counter;
        private static int Counter = 0;
        //{
        //    get;private set;
        //    //get { return counter; }
        //    //private set { counter = value; } }
        ////internal timer(int a)
        ////{
        ////    this.counter = a;
        //}
        public void timerstart()
        {
            Thread.Sleep(5000);
            Counter++;
            Console.WriteLine("+1");
        }
        public void displaycounter()
        {
            Console.WriteLine($"Current count is: {Counter}");
        }



    }
}

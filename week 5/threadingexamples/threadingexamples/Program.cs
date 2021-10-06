using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace threadingexamples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Calling sleep task method");
            Thread background_Thread = new Thread(new ThreadStart(sleepTask));
            background_Thread.IsBackground = true;
            Console.WriteLine("thread_name.IsBackground" + background_Thread.IsBackground);
            background_Thread.Start();


            Console.WriteLine("Calling do something method");
            Thread foreground_Thread = new Thread(new ThreadStart(doSomething));
            Console.WriteLine("thread_name_1.IsBackground" + foreground_Thread.IsBackground);
            foreground_Thread.Start();


            Thread th = new Thread(new ParameterizedThreadStart(parameterisedsleepTask));
            th.Start(10);


            Console.WriteLine("Done with main program.");
            Console.ReadLine();
        }

        public static void parameterisedsleepTask(object sleepduration)
        {
            Console.WriteLine("In Background task, taking a nap");
            Thread.Sleep((int)sleepduration * 1000);
            Console.WriteLine("I am done with background task");
        }

        public static void sleepTask()
        {
            Console.WriteLine("In sleepTask, taking a nap");
            Thread.Sleep(10000);
            Console.WriteLine("Doing some work");
            Thread.Sleep(10000);
            Console.WriteLine("I am done working");
        }

        public static void doSomething()
        {
            Thread.Sleep(5000);
            Console.WriteLine("Perform task quickly");
        }
    }
    }
}

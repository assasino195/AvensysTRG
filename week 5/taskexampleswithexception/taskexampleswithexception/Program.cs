using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace TaskExample
{
    class Program
    {
        public static void Main(string[] args)
        {
            //TaskDeclarationMethod();

            //Console.WriteLine("Calling TaskRunExample method");
            //TaskRunExample().Wait();
            //Console.WriteLine("Back in main method");

            //TaskWaitAllExample();

            //TaskWithFunction();

            //ExceptionInTask();

            //ExceptionHandlingInMultipleTask();

            TaskWhenAnyExample();
        }

        private static async void TaskWhenAnyExample()
        {
            Random rand = new Random();
            var tasks = Enumerable.Range(1, 5).Select(n => Task.Run(() =>
            {
                Console.WriteLine("In task: " + n);
                Thread.Sleep(rand.Next(1000, 10000));
                return n;
            }));
            var temp = Task.WhenAny(tasks.ToArray());
            var completedTask = await temp;
            Console.WriteLine("The completed task ID is: " + await completedTask);

            await Task.WhenAll(tasks.ToArray());
            Console.WriteLine("All tasks completed");
        }

        private static void ExceptionHandlingInMultipleTask()
        {
            var tasks = new List<Task<int>>();
            Func<object, int> func = (obj) =>
            {
                int i = (int)obj;
                if (i == 6)
                {
                    throw new ArgumentNullException();
                }
                if (i >= 2 && i <= 5)
                {
                    throw new InvalidOperationException();
                }
                Console.WriteLine("Task ID: " + Task.CurrentId);
                Console.WriteLine("Task ID for this task: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Task executed with value: " + i);
                return 100 * (int)obj;
            };
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task<int>.Factory.StartNew(func, i));
            }
            try
            {
                Task.WaitAll(tasks.ToArray());
                Console.WriteLine("In try block completed running all tasks");
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("Exception raised as expected");
                for (int j = 0; j < ex.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("Inner exception caught: " + ex.InnerExceptions[j]);
                }
            }
        }

        private static void ExceptionInTask()
        {
            var task1 = new Task.Run(() => { throw new InvalidOperationException(); });
            try
            {
                task1.Wait();
            }
            catch (AggregateException ex)
            {
                Console.WriteLine("This is expected");
                Console.WriteLine("Exception raised is: " + ex.InnerException);
            }
        }
        private static void TaskWithFunction()
        {
            Func<object, int> func = (obj) =>
            {
                Console.WriteLine("In task with function with parameter: " + obj);
                return ((int)obj) * 100;
            };

            Task t1 = new Task<int>(func, 5);
            t1.RunSynchronously();
            t1.Wait();

            var result = Task<int>.Run(() =>
            {
                return func(100);
            });
            Console.WriteLine("Return value of result is: " + result.Result);
        }
        public static void TaskWaitAllExample()
        {
            var tasks = new List<Task>();
            //var tasks = new Task[10];

            Action<object> action = dosomething;
            for (int i = 0; i < 10; i++)
            {
                tasks.Add(Task.Factory.StartNew(action, i));
            }

            Task.WaitAll(tasks.ToArray());
        }
        public static async Task TaskRunExample()
        {
            Console.WriteLine("In TaskRunExample method");

            await Task.Run(() =>
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("In task.run " + i);
                    Thread.Sleep(500);
                }
            });
            Console.WriteLine("Going out of TaskRunExample method");
        }
        private static void TaskDeclarationMethod()
        {
            Action<object> action = dosomething;
            Action<object> action1 = dosomething1;

            //First way to declare a task
            Task t1 = new Task(action, "apple");
            t1.Start();

            Task t2 = new Task(action, "ball");
            t2.Start();

            //Second way to declare a task
            Task t3 = Task.Factory.StartNew(action, "cat");

            //Third way to declare a task
            Task t4 = Task.Run(() =>
            {
                Console.WriteLine("Task ID: " + Task.CurrentId);
                Console.WriteLine("Task ID for this task: " + Thread.CurrentThread.ManagedThreadId);
                Console.WriteLine("Thread background value: " + Thread.CurrentThread.IsBackground);
                //Console.WriteLine("Task executed with value: " + somevalue);
            });

            Task t5 = new Task(action1, "eagle");
            t5.RunSynchronously();

            t1.Wait();
            t2.Wait();
            t3.Wait();
            t4.Wait();
            Console.ReadLine();
        }
        public static void dosomething(object somevalue)
        {
            Thread.Sleep(2000);
            Console.WriteLine("Task ID: " + Task.CurrentId);
            Console.WriteLine("Task ID for this task: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Thread background value: " + Thread.CurrentThread.IsBackground);
            Console.WriteLine("Task executed with value: " + somevalue);
        }
        public static void dosomething1(object somevalue)
        {
            Console.WriteLine("Task ID: " + Task.CurrentId);
            Console.WriteLine("Task ID for this task: " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Task executed with value: " + somevalue);
        }
    }
}
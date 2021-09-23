using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace delegateventwithtimere
{
    class Program
    {
        public delegate void EventHandler(int count);
        class Ops
        {
            public event EventHandler send;
            int c;
            public void getinput(int c)
            {
                this.c = c;
                checkcount();
                notify();
            }
            public void checkcount()
            {
                if(c>19)
                {
                    Console.WriteLine("Event Received");
                    Thread.Sleep(3000);
                }
               
            }
            private void notify()
            {
                if (send != null)
                {
                    send(c);
                }
            }
        }
        class subscribe
        {
            
            public static void print()
            {
                Ops opss = new Ops();
                opss.send += op_send;
                for (int c=1;c<22;c++)
                {
                    opss.getinput(c);
                }
                Console.ReadLine();
            }

            static void Main(string[] args)
            {
                print();
            }
            private static void op_send(int count)
            {
                Console.WriteLine("count is :"+count);
                Thread.Sleep(500);
            }
        }
    }
}

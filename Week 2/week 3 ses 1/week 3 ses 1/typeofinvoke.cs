using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    class typeofinvoke
    {
        delegate void customdel(int s);
        static void Main2(string[] args)
        {

        }
        public static int printa(int a)
        {
            for(int i=0; i<10;i++)
            {
                Console.WriteLine("Value of a after increment"+(a++));
                Thread.Sleep(500);
                
            }
            return a * a;
        }
        private static void AsynchronousdelegateExample()
        {
            //customdel del = new customdel(printa);
            //Console.WriteLine("starting to execute custom del");
            //IAsyncResult asyncresult = del.BeginInvoke(4, null, null);
            //Console.WriteLine("custom del execution ended");
            //int result = del.EndInvoke(asyncresult);
            //Console.WriteLine("square result is"+result);

        }
        private static void SynchronousDelegateExample()
        {
            //customdel del = new customdel(returnsquare);

            Console.WriteLine("starting to execute custom del");

        }
    }
}

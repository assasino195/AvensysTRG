using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    class eventsexample
    {
        static void Main(string[] args)
        {
            //NewMethod();
            publisher pub = new publisher();
            subscriber sub = new subscriber();
            sub.SubscribeToEvent(pub);
            pub[0] = 3;
            pub[1] = 5;
            sub.Unsubscribetoevent();
            pub[2] = 4;
            Console.ReadLine();
        }
        
        private static void NewMethod()
        {
            addition add = new addition();
            add.addcompletedevent += Add_addCompletedEvent;
            add.performAddEvent += add_PerformCompletedEvent;//calling the private void below to execute
            add.Adde(3, 4);
        }

        private static void Add_addCompletedEvent(int res)
        {
            Console.WriteLine("COMPLETEE");
        }
        private static void add_PerformCompletedEvent(int a,int b)
        {
            Console.WriteLine("Completed addition event");

        }
        
    }
}

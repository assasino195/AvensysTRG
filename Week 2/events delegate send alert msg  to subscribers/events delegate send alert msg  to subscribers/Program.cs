using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_delegate_send_alert_msg__to_subscribers
{
    class Program
    {
        static void Main(string[] args)
        {
            publisher pub = new publisher();
            subscriber sub = new subscriber();
            sub.SubscribeToEvent(pub);
            Console.WriteLine("Enter ur msg");
            string input = Console.ReadLine();
            pub[0] = input;
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_delegate_send_alert_msg__to_subscribers
{
    class subscriber
    {
        private publisher pub;
        public void SubscribeToEvent(publisher pubish)
        {
            pub = pubish;
            pub.alertadded += pub_alertadded;
        }
        public void pub_alertadded(object obj,EventArgs e)
        {
            Console.WriteLine("New Alert has been published "+pub[0]);
        }
    }
}

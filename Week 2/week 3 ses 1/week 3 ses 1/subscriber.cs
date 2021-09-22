using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_3_ses_1
{
    class subscriber
    {
        private publisher pub;
        public void SubscribeToEvent(publisher publisher)
        {
            pub = publisher;
            pub.dataAdded += pub_dataAdded;
        }
        private void pub_dataAdded(object sender,EventArgs e)
        {
            Console.WriteLine("data added in list");
        }
        public void Unsubscribetoevent()
        {
            pub.dataAdded -= pub_dataAdded;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateventwithtimere
{
    class subscriber
    {
        private counter cs;
        public void SubscribeToEvent(counter publisher)
        {
            cs = publisher;
            //cs.Count += pub_countadded;
        }
        public void pub_countadded(object sender,EventArgs e)
        {
            Console.WriteLine("Event Received");
        }
    }
}

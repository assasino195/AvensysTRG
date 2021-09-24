using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace delegate_and_events_password_encrypt
{
    class subscriber
    {
        private publisher pub;

        public void subscribetoevent(publisher publish)
        {
            pub = publish;
            pub.passwordadded += pub_pwadded;
        }   
        public void pub_pwadded(object sender,EventArgs e)
        {
            Console.WriteLine($"You have added{sender} to list");
            Thread.Sleep(2000);
        }
        
    }
}

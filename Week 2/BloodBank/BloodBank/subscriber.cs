using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    class subscriber
    {
        

        private publisher pub;
        public void subscribetoevent(publisher publish)
        {
            pub = publish;
            //pub.send += bloodalert;
        }
        private void bloodalert(string blood,int count)
        {
            Console.WriteLine($"you have added {blood} Type Blood with {count} to List");
        }
        //private void bloodalert(object sender,EventArgs e)
        //{
        //    Console.WriteLine($"you have added {sender} to List");
            
        //}
       
    }
}

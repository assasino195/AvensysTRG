using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketbooking
{
    class train
    {
        public string name { get; set; }
        public string id { get; set; }
        public int maxcap { get; set; }
        public double price { get; set; }
        public train(string n,string i,int mc,double pr)
        {
            name = n;
            id = i;
            maxcap = mc;
            price = pr;
        }
        public double calculatetotal(int no)
        {

            return price * no;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSys
{
    class customer
    {
        public string name { get; set; }
        public string id { get; set; }
        public DateTime lastvisited { get; set; }
        public int daysvisited { get; private set; }
        public List<string> servicesgiven = new List<string>();
        public string documents
        {
            get; set;
        }
        public bool approvals { get;private set; }
        
        public customer(string n,string i)
        {
            name = n;
            id = i;
        }
        public void checkapproval()
        {
            if(daysvisited>6 && documents!=null)
            {
                approvals = true;
            }
            else
            {
                approvals= false;
            }
        }
        public void logcustomersvc(employee e)
        {
            servicesgiven.Add($"{e.name} {e.id} served {name} {e.role} on {lastvisited}");
        }
    }
}

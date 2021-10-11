using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSys
{
    class employee
    {
        public string role { get; set; }
        public string name { get; set; }
        public string id { get; set; }
        List<string> servicesdone = new List<string>();
        public DateTime todaysdate { get; set; }
        public employee(string r,string n,string i)
        {
            role = r;
            name = n;
            id = i;
        }
        public void logsvc(customer c)
        {
            servicesdone.Add($"{name} {id} served {c.name} {role} on {todaysdate}");
        }

    }
}

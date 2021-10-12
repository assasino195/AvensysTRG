using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Office_management_sys
{
    class workers
    {
        public string name { get; set; }
        public string id { get; set; }
        public string role { get; set; }
        public string taskassigned { get; set; }
        public List<string> worksubmitted = new List<string>();
        public workers(string n,string i,string r)
        {
            name = n;
            id = i;
            role = r;
        }
        public void assigntask(string task,workers w)
        {
            if(role!="User")
            {
                if(w.role=="User")
                {
                    w.taskassigned = task;
                    Console.WriteLine($"{w.name} {w.id} has been assigned {task} by {name} {id} {role}");
                }
            }
        }
        public void submitwork(string work)
        {
            if(role=="User")
            {
                DateTime dt = DateTime.UtcNow.AddHours(8);
                worksubmitted.Add($"{name} {id} has submitted work on {dt}\n{work}");
            }
        }
    }
}

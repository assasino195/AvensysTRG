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
        public bool worksubmitted { get; set; }
        public workers(string n,string i,string r,bool work)
        {
            name = n;
            id = i;
            role = r;
            worksubmitted = work;
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
                worksubmitted = true;
            }
        }
        public override string ToString()
        {
            string output = id + "," + name + "," + role+","+worksubmitted;
           
            return $"{id},{name},{worksubmitted},{role}";
        }
    }
}

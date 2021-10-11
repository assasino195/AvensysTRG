using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUestion_2
{
    class Patient
    {
        public string name { get; set; }
        public string id { get; set; }
        public string hist { get; set; }
        public string issue{get;set;}
        public int countemg { get; set; }
        public int clic { get; set; }
        public int spec { get; set; }
        public DateTime visited { get; set; }
        public Patient(string n,string i,string issue)
        {
            name = n;
            id = i;
            //hist = h;
            //countemg = emg;
            //clic = c;
            //spec = s;
            this.issue = issue;

        }
        public void emergency(DateTime t)
        {
            issue += $"{t} visited Emergency.";
            Console.WriteLine("You have been sent to emergency-ward");
            countemg++;

        }
        public void clinicalop(DateTime t)
        {
            clic++;
            issue += $"{t} visited clinical-Operations.";
            Console.WriteLine("you have been sent to clinical-operations");
        }
        public void specialist(DateTime t)
        {
            spec++;
            issue += $"{t} visited Specialist.";
            Console.WriteLine("you have been sent to specialist");

        }
    }
}

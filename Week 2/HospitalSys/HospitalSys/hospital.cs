using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalSys
{
    class hospital
    {
        public string patientname { get; set; }
        public string condition { get; set; }
        public double charges { get; set; }
        public hospital (string patientname, string condition,double charges)
        {
            this.patientname = patientname;
            this.condition = condition;
            this.charges = charges;
        }
        public void department()
        {
            Console.WriteLine($"Please Head over to {condition} Department.");
        }
        public void calculatecharges()
        {
            Console.WriteLine($"Total charges are $5 + {charges}");
        }
        
    }
}

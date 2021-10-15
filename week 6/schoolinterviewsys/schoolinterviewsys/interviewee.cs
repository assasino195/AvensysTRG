using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace schoolinterviewsys
{
    class interviewee
    {
        public string name { get; set; }
        public double marks { get; set; }
        public double teachingexp { get; set; }
        public interviewee(string n,double m,double t)
        {
            name = n;
            marks = m;
            teachingexp = t;
        }
    }
}

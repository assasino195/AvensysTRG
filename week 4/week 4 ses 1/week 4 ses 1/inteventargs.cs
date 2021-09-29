using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_4_ses_1
{
    class inteventargs:EventArgs
    {
        public double input1 { get; private set; }
        
        public inteventargs(double a)
        {
            input1 = a;
           
        }

        //public inteventargs(int i)
        //{
        //    someproperty = i;
        //}
        //public int someproperty { get; set; }
    }
}

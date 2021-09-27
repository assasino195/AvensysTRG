using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    class maintimer:timer
       
    {
        timer timerss = new timer();
        int counters;
        public bool isCounterRunning { get; set; }
        public maintimer(bool b)
            {
                isCounterRunning = b;
            
            }
        
    }
}

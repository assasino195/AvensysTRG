using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
namespace Week3Test
{
    class backgroundtimer
    {
        private static System.Timers.Timer ttimer;        public bool IsCounterRunning { get; private set; }        private int counter = 0;        public void Start()        {            ttimer = new System.Timers.Timer(5000);            ttimer.Elapsed += Increment;            ttimer.AutoReset = true;            ttimer.Enabled = true;            IsCounterRunning = true;        }        public void Stop()        {            ttimer.Enabled = false;            IsCounterRunning = false;            Console.WriteLine(counter);        }        public void Increment(Object source, ElapsedEventArgs e)        {            counter += 1;        }
    }
}

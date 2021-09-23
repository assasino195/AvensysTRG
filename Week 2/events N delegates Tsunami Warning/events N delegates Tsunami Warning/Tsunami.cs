using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_N_delegates_Tsunami_Warning
{
    class tsunami
    {
        public delegate void EventHandler (string place, double intensity);
       
            public event EventHandler send;
            double inten;
            string place;
            double probability;
            public void getInput(string place,double inten)
            {
                this.place = place;
                this.inten = inten;
                calculateintensity();
                notify();
            }

            public void calculateintensity()
            {
                probability = inten * 0.7 + 0.3;
            }
            private void notify()//sends back the values to the subscriber to be displayed
            {
                if(send!=null)
                {
                    send(place, probability);
                }
            }
        
    }
}

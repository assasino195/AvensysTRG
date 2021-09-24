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
        private earthquake quake;
           // double probability;
            public void getInput(string place,double inten)
            {
                this.place = place;
                this.inten = inten;
                //calculateintensity();
                notify();
                
            }

            
            private void notify()//sends back the values to the subscriber to be displayed
            {
                if(send!=null)
                {
                    send(place, inten);
                }
            }
        public void subscribetoevent(earthquake quake)
        {
            this.quake = quake;
            quake.send += Quake_send;

        }

        private void Quake_send(double chance)
        {
            Console.WriteLine($"Chance of tsunami happening: {chance}");
        }

        
        
    }
}

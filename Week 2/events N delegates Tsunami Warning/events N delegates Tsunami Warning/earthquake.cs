using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_N_delegates_Tsunami_Warning
{
    class earthquake
    {
        public delegate void EventHandler(double chance);
        public event EventHandler send;
        private tsunami tsu;
        double probability;
        double intensity;
        public double calculateintensity()
        {

            Random ran = new Random();
            probability = intensity * 0.7 + 0.3 * (ran.Next(0, 100) / 100);
            return probability;
        }
        public void subscribetoevent(tsunami tsu)
        {
            this.tsu = tsu;
            tsu.send += tsualertadded;//sub scribe to event and this method will call
        }
        private void notify()//sends back the values to the subscriber to be displayed
        {
            if (send != null)
            {
                send(probability);
            }
        }

        public void tsualertadded(string n,double i)//printing part important to add in the values from the publisher to be displayed
        {
            intensity = i;
            Console.WriteLine($"Location of Tsunami is: {n}\n intensity of earth quake is: {i}");
            notify();
            
        }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace events_N_delegates_Tsunami_Warning
{
    class earthquake
    {

        private tsunami tsu;
        public void subscribetoevent(tsunami tsu)
        {
            this.tsu = tsu;
            tsu.send += tsualertadded;
        }

        public void tsualertadded(string n,double i)
        {
            
            Console.WriteLine($"Location of Tsunami is: {n}\n probability of tsunami is: {i}");
        }
        
    }
}

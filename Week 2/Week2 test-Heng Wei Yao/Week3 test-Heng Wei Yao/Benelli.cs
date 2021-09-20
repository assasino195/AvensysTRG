using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class Benelli : bike
    {
        enum obj
        {
            LEDLight,
            ABS,
            USDSuspension,
            LaunchControl,
            TractionControl
        }
        public int speed { get; private set; }

        public int enginecapacity { get; private set; }

        public int torque { get; private set; }

        
        

        public void showbikeinfo()
        {
            throw new NotImplementedException();
        }
    }
}

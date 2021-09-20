using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class SecondClass
    {
        public double costperkm { get; private set; }

        public double distanceoftravel { get; private set; }
        public SecondClass(double distanceoftravel)
        {
            this.costperkm = 30;
            this.distanceoftravel = distanceoftravel;
        }

        public double costofflight()
        {
            return costperkm * distanceoftravel;
        }
    }
}

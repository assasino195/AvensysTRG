using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class ThirdClass
    {
        public double costperkm { get; private set; }

        public double distanceoftravel { get; private set; }
        public ThirdClass(double distanceoftravel)
        {
            this.costperkm = 20;
            this.distanceoftravel = distanceoftravel;
        }

        public double costofflight()
        {
            return costperkm * distanceoftravel;
        }
    }
}

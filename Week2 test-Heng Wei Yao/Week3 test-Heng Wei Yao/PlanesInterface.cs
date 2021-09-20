using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    interface PlanesInterface
    {
        //string Membership{get;}
        double costperkm { get; }
        double distanceoftravel { get; }
        double costofflight();
    }
}

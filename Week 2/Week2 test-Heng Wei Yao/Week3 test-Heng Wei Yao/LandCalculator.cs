using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class LandCalculator:rectangle
    {
        double cost 
        { 
            get;
            set; 
        }
        public LandCalculator(double cost,double length,double breadth):base(length,breadth)
        {
            this.cost = cost;
        }
        public double totalcost(double len,double cost,double breadth)
        {
            return len * breadth * cost;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3_test_Heng_Wei_Yao
{
    class unbox
    {
        
        
        public object ManipulateObj(object a)
        {
            var a1 = (string)a;
            char[] charArray = a1.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
        //public object ManipulateObj(object a)
        //{
        //    var a1 = (int)a;
            
        //    return new string(charArray);
        //}
    }
}

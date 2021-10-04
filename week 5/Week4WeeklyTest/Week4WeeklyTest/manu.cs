using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week4WeeklyTest
{
    class demo{ 
    
    }
    class manu
    {
        //public delegate void eventhandler(object a, object b);
        
      

      
        public object Add(object a, object b)
        {
            int k,o;
            if (int.TryParse((string)(a),out k)&& int.TryParse((string)(b), out o)) //&& (b is int intt2))
            {
                int output = k + o;
                return output;
            }
            else if (a is string str && b is string str1)
            {
                string output = str;
                output += str1;
                return output;
            }
            else if (a is List<object> lst1 && b is List<object> lst2)

            {
                List<object> op = new List<object>();
                op.Add(lst1);
                op.Add(lst2);
                return op;
            }
            else if (a is Type && b is Type )
            {
                List<Type> i = new List<Type>();
                i.Add((Type)a);
                i.Add((Type)b);
                return i;
            }

            else
            {
                return "not supported";
            }

        }
    }
}

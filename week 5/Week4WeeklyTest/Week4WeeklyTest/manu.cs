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
            if (a is Type && b is Type) //&& (b is int intt2))
            {
                List<Type> i = new List<Type>();
                i.Add((Type)a);
                i.Add((Type)b);
                return i;
            }
            else if (a is string str && b is string str1)
            {
                string output = str;
                output += str1;
                return output;
            }
            else if (a is List<string> lst1 && b is List<string> lst2)

            {
                List<string> op = new List<string>();
                op.AddRange(lst1);
                op.AddRange(lst2);
                for (int i = 0; i < op.Count; i++)
                {
                    Console.WriteLine(op[i]);
                }
                return op;
                 
              
                
            }
            else if (int.TryParse((string)(a), out k) && int.TryParse((string)(b), out o))
            {
               
                int output = k + o;
                return output;
            }
            

            else
            {
                return "not supported";
            }

        }
    }
}

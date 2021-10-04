using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    class Class1<T> : Interface1<T>
    {
        public T Var1 { get; private set; }
        public T var2 { get; private set; }
        public T var3 { get; private set; }
        public Class1(T t1,T t2,T t3)
        {
            Var1 = t1;
            var2 = t2;
            var3 = t3;
        }
    

       

        public bool validate()
        {
           
            if (Var1 is int)
            {
                return true;
            }
            else { return false; }
        }

        public T inspect()
        {
            return var3;
        }
    }
}

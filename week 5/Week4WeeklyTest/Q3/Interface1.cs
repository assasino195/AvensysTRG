using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q3
{
    interface Interface1<T>
    {
        

        T Var1 { get; }
        T var2 { get; }
        T var3 { get; }
        bool validate();
        T inspect();
    }
}

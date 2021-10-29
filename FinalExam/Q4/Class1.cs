using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q4
{
    class Class1
    {
        string name { get; set; }
        public Class1(string name)
        {
            this.name = name;
        }
        public string returnname()
        {
            return this.name;
        }
    }
}

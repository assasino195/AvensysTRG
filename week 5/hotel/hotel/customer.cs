using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class customer
    {
        public string name { get; set; }
        public string id { get; set; }
        public stay sty { get; set; }
        public customer(string name,string id)
        {
            this.name = name;
            this.id = id;
        }
    }
}

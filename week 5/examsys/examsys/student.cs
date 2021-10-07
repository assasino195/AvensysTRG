using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examsys
{
    class student
    {
        
        public string name { get; set; }
        public string id { get; set; }
        
        public student(string name, string id)
        {
            this.name = name;
            this.id = id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    class package
    {
        public int trackingid { get; private set; }
        public string sendername { get; private set; }
        public string receivername { get; private set; }
        public string address { get; private set; }
        public package(int id,string sendname,string receivname,string add)
        {
            trackingid = id;
            sendername = sendname;
            receivername = receivname;
            address = add;
        }

    }
}

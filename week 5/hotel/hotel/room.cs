using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class room
    {
        public string roomname { get; set; }
        public string roomno { get; set; }
        public double dailyrates { get; set; }
        public bool isAvail { get; set; }
        
        public room(string rname,string rno,double dr,bool ia)
        {
            roomname = rname;
            roomno = rno;
            dailyrates = dr;
            isAvail = ia;
        }
        
    }
}

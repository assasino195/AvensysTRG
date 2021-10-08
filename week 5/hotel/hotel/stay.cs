using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class stay
    {
        public int daystaying { get; set; }
        public List<string> logs = new List<string>();
        public DateTime checkindate { get; set; }
        public DateTime checkoutdate { get; set; }
        public double totalcharge { get;  set; }
        public static Dictionary<int, room> roomdata { get; set; }
        public static IEnumerable<room> roomlist { get; set; }
        private int dictid = 0;
        public stay()
        {

        }
        //public stay() { }
        public stay(DateTime cid,DateTime cod)

        {
            checkindate = cid;
            checkoutdate = cod;

        }
        public void addroomtormlist(room r)
        {
            List<room> temp = new List<room>();

            temp.Add(new room(r.roomname, r.roomno, r.dailyrates, r.isAvail));
            roomlist = temp;
            roomdata = new Dictionary<int, room>();
            roomdata.Add(dictid, r);
            dictid++;
            //roomlist.Concat(r));
            foreach(room a in roomlist)
            {
                Console.WriteLine(a.roomname+a.roomno);
            }    
            //roomlist.Join(r);/roomlist.Add(new room(r.roomname, r.roomno, r.dailyrates, r.isAvail));
        }
        public double totalcharges(double r)
        {
            double total = 0;
            //foreach(room r in roomlist)
            //{
                total = (checkoutdate - checkindate).TotalDays * r;
            // }
            totalcharge = total;
            return total;
        }
        public void addtolist(room r)
        {
            //logs.Add($"{c.name} {c.id} stayed at {roomname} {roomno} at {dailyrates} for {daystaying} for a total of {totalcharges()}");
            // foreach(room rm in roomlist)
            // {
            //roomlist.Add(r);
            //}
        }

    }
}

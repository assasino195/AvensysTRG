using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketbooking
{
    class customer
    {
        public string cusname { get; set; }
        public string cusid { get; set; }
        public string phonenumber { get; set; }
        public string email { get; set; }
        public customer(string cn, string ci, string pn, string em)
        {
                cusname = cn;
                cusid = ci;
                phonenumber = pn;


                email = em;
            
            
        }
        
    }
}

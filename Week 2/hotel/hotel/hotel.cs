using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class hotel
    {
        public delegate void EventHandler(string roomtype, double roomrate, double stayingdays);
        public string name { get; set; }
        public double roomrate{get;set;}
        public double stayingdays { get; set; }
        public bool checkedin { get; set; }
        public void calculateroomrate()
        {
            Console.WriteLine($"Room rate is {roomrate} Staying days is: {stayingdays} total amount is: {roomrate * stayingdays}");
        }
        public hotel(string name,double roomrate,double stayingdays,bool checkedin)
        {
            this.name = name;
            this.roomrate = roomrate;
            this.stayingdays = stayingdays;
            this.checkedin = checkedin;
        }
        public void printall()
        {
            Console.WriteLine($"Room Type: {name}\nRoomRate{roomrate}\nstaying days{stayingdays}\n");
        }
    }
}

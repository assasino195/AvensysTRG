using System.Collections.Generic;
using System.Threading;
namespace ticketbooking
{
    class booking
    {
        public  Dictionary<string, bool> seats = new Dictionary<string, bool>();
        public  Dictionary<string, string> bookingls = new Dictionary<string, string>();
        public static string cusid { get; set; }
        public static string movieid { get; set; }
        public static string  seatid { get; set; }
        public void generateseats(int maxcap)
        {

            for (int i = 0; i < maxcap; i++)
            {
                if (seats.ContainsKey($"A{i}"))
                {

                }
                else
                {
                    string ad = $"A{i.ToString()}";
                    seats.Add(ad, true);
                }
            }
        }
        
        public void threadbooking()
        {
            Thread background_Thread = new Thread(new ThreadStart(bookingseats));
            background_Thread.IsBackground = true;
            background_Thread.Start();
            System.Console.WriteLine("booking completed");
            string temp = $"{cusid} {movieid} {seatid}";
            if(bookingls.ContainsKey(cusid))
            {
                string tem = bookingls[cusid];
                 tem+= "," + temp;
                bookingls[cusid] = tem;
            }
            else { bookingls.Add(cusid, temp); }
            
        }
        public  booking()
        {
           

        }
        public void  setbooking(string id, string movieids, string seatids)
        {
            cusid = id;
            movieid = movieids;
            seatid = seatids;
        }
        public void bookingseats()
        {

            if (seats.ContainsKey(seatid))
            {
                if (seats[seatid])
                {
                    seats.Remove(seatid);
                    seats.Add(seatid, false);
                    
                }
                else

                {
                    System.Console.WriteLine("Seats Taken or doesn't exist");
                }
            }
        }
        public void addtobooklist(string id,string all)
        {
            bookingls.Add(id, all);
        }
        public void addtoseatslist(string id,bool all)
        {
            seats.Add(id, all);
        }
        public void checkbooking(string id)
        {
            if(bookingls.ContainsKey(id))
            {
                System.Console.WriteLine("Booking "+bookingls[id]);
            }
        }
       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            List<room> rmlst = new List<room>();
            List<customer> cslst = new List<customer>();
              List<string> logs = new List<string>();
            rmlst.Add(new room("east side", "101", 32,true));
            rmlst.Add(new room("west side", "102", 35,true));
            rmlst.Add(new room("south side", "103", 40,true));
            cslst.Add(new customer("public acc", "999"));
            bool stay = true;
            while(stay)
            {
                Console.WriteLine(  "Welcome to Hotel Compass");

                Console.WriteLine("Please Enter your Name");
                string inputname = Console.ReadLine();
                Console.WriteLine("Please Enter your ID");
                string inputid = Console.ReadLine();
                bool newcus = true ;
                foreach(customer c in cslst)
                {
                    if(c.id.Equals(inputid))
                    {
                        newcus = false;
                        Console.WriteLine($"Welcome {c.name}");
                        Console.WriteLine($"1.Book a Room\n2.Check Out\n3.Display history of booked room\n4.Exit");
                       
                        string decisioninput = Console.ReadLine();
                        switch (decisioninput)
                        {
                            case "1":
                                {
                                   
                                    foreach (room rm in rmlst)
                                    {
                                        if (rm.isAvail)
                                        {
                                            Console.WriteLine($" {rm.roomno}: {rm.roomname} {rm.dailyrates}");
                                            
                                        }
                                    }
                                    Console.WriteLine("enter the room ID you wish to book");
                                    string inputroomid = Console.ReadLine();
                                    foreach(room rm in rmlst)
                                    {
                                        if (rm.roomno.Equals(inputroomid) && rm.isAvail)
                                        {
                                            bool temp = true;
                                            while (temp)
                                            {
                                                Console.WriteLine("Please Enter starting date you wish to book");
                                                bool pass = DateTime.TryParse(Console.ReadLine(), out DateTime dtinput);
                                                if (pass)
                                                {
                                                    Console.WriteLine("Please Enter End date you wish to book");
                                                    bool pass2 = DateTime.TryParse(Console.ReadLine(), out DateTime dtoutput);
                                                    if (pass2)
                                                    {
                                                        List<room> templst = new List<room>();
                                                        templst.Add(rm);
                                                        temp = false;
                                                        rm.isAvail = false;
                                                        c.sty = new stay(dtinput, dtoutput);
                                                       // c.sty.roomlist.Add(new room(rm.roomname,rm.roomno,rm.dailyrates,false));
                                                       // c.sty.roomlist.AddRange(templst);
                                                        Console.WriteLine($"Total Charges Are: {c.sty.totalcharges(rm.dailyrates)}");
                                                        c.sty.logs.Add(rm.roomno);
                                                        // c.sty.addtolist(c,rm.roomname,rm.roomno,rm.dailyrates);
                                                        // c.sty.addtolist(rm);
                                                        //c.sty.roomlist.Add(rm);
                                                        // c.sty = sty;
                                                        c.sty.addroomtormlist(rm);
                                                        logs.Add($"{c.name} {c.id} stayed at {rm.roomname} {rm.roomno} at {rm.dailyrates} for {(c.sty.checkoutdate - c.sty.checkindate).TotalDays} days for a total of {c.sty.totalcharge}");
                                                    }

                                                }
                                                
                                            }
                                        }
                                    }
                                    break;
                                }
                            case "2":
                                {
                                    
                                    foreach(string r in c.sty.logs)
                                    {
                                        foreach(room rm in rmlst)
                                        {
                                            if(r.Equals(rm.roomno))
                                            {
                                                rm.isAvail = true;
                                            }
                                        }
                                        
                                    }
                                    c.sty.logs.Clear();
                                    //c.sty.roomlist.Clear();
                                    Console.WriteLine("Successfully Checked Out Hope You Enjoyed Your Stay!");
                                    break;
                                }
                            case "3":
                                {
                                   foreach(string k in logs)
                                    {
                                        Console.WriteLine(k);
                                    }
                                    break;
                                }
                            case "4":
                                {
                                    stay = false;
                                    break;
                                }
                            case "5":
                                {
                                    Console.WriteLine("enter room id you wish to search");
                                    string input6 = Console.ReadLine();
                                    foreach(string a in logs)
                                    {
                                        string[] tempp = a.Split(' ') ;
                                        Console.WriteLine(a);
                                        if(tempp[4].Equals(input6))
                                        {
                                            Console.WriteLine(a);
                                        }
                                        
                                        
                                    }
                                    break;
                                }
                           
                                   
                                
                        }
                        
                    }
                    else if(c.id.Equals(inputid))
                    {
                        newcus = false;
                        Console.WriteLine("print history");
                        foreach (customer k in cslst)
                        {
                            try
                            {
                                foreach (string a in k.sty.logs)
                                {
                                    Console.WriteLine(a);
                                }
                            }
                            catch(ArgumentNullException e)
                            {
                                Console.WriteLine("NUll list"+e.Message);
                            }
                        }
                    }
                   
                       
                    
                }
                if(newcus)
                {
                    cslst.Add(new customer(inputname, inputid));
                    Console.WriteLine("added new customer");
                    
                }
            }
        }
    }
}

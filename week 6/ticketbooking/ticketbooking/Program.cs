using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ticketbooking
{
    
    class Program
    {
       
        public static void initlist()
        {
            
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool isvalidphoneno(string phoneno)
        {
            int count=0;
            foreach(char a in phoneno)
            {
                if(count==0)
                {
                 if(a=='8'||a=='9')
                    {
                        
                    }
                 else
                    {
                        return false;
                    }
                }
                count++;
            }
            if(count==8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static void Main(string[] args)
        {
            booking book = new booking();
            Dictionary<string, customer> cusdic = new Dictionary<string, customer>();
            Dictionary<string, train> trainlst = new Dictionary<string, train>();
           // trainlst.Add("01",new train("Express", "01", 10, 0));
            Dictionary<string, string> bookinglst = new Dictionary<string, string>();
            //Dictionary<string, int> capcheck = new Dictionary<string, int>();
            //capcheck.Add("01", 0);

            string filepath = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\ticketbooking\ticketbooking\bin\Debug\cusdic.txt";
            
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entires = line.Split(',');
                
                customer tempcus = new customer(entires[0], entires[1], entires[2], entires[3]);
                cusdic.Add(entires[0],tempcus);
                //List<string> booklst = new List<string>();
                
            }
            string filepath2 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\ticketbooking\ticketbooking\bin\Debug\traindic.txt";
            
            List<string> lines2 = File.ReadAllLines(filepath2).ToList();
            foreach (var line in lines2)
            {
                string[] entires = line.Split(',');
                int temp = 0;
                double temp1 = 0;
                try
                {
                    temp = int.Parse(entires[2]);
                    temp1 = double.Parse(entires[3]);
                    train temptr = new train(entires[1], entires[0], temp, temp1);
                    trainlst.Add(entires[1], temptr);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error found {e.Message}");
                }
                
                

            }
            string filepath3 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\ticketbooking\ticketbooking\bin\Debug\bookinglist.txt";
            List<string> lines3 = File.ReadAllLines(filepath3).ToList();
            foreach (var line in lines3)
            {
                string[] entires = line.Split(',');

                book.addtobooklist(entires[0], entires[1]);
            }
            string filepath4 = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\ticketbooking\ticketbooking\bin\Debug\seatlist.txt";
            List<string> lines4 = File.ReadAllLines(filepath4).ToList();
            foreach (var line in lines4)
            {
                string[] entires = line.Split(',');
                try

                {
                    bool tem=bool.Parse(entires[1]);
                    book.addtoseatslist(entires[0], tem);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"error found {e.Message}");
                }
            }
            //string filename = "officeemployees.txt";
            //string fullfilename = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\Office management sys\Office management sys\bin\Debug";
            //FileStream fs = new FileStream($"{ filename}.txt", FileMode.Open, FileAccess.Read);
            //StreamReader sr = new StreamReader(fs);

            //sr.BaseStream.Seek(0, SeekOrigin.Begin);


            Console.WriteLine("welcome admin please set the max cap for today");
            int.TryParse(Console.ReadLine(), out int adminin);
            book.generateseats(adminin);

            bool stay = true;
            while(stay)
            {
                Console.WriteLine("Enter ID");
                string idinput = Console.ReadLine();
                if (cusdic.ContainsKey(idinput))
                {
                    Console.WriteLine("1.Book new ticket\n2.Check existing ticket\nQ.Exit");
                    string choice = Console.ReadLine().ToLower();
                    switch(choice)
                    {
                        case "1":
                            {
                                Console.WriteLine("Current tickets available");
                                foreach (var train in trainlst)
                                {
                                    Console.WriteLine($"{train.Value.id}: {train.Value.name} {train.Value.price}");
                                }
                                string selectedid = Console.ReadLine();
                                bool bookingseatss = true;
                                while (bookingseatss)
                                {
                                    foreach (var seatsdic in book.seats)
                                    {
                                        if(seatsdic.Value)
                                        {
                                            Console.WriteLine(seatsdic.Key);
                                        }
                                    }
                                    Console.WriteLine("Enter seat number you wish to book or Q to exit");
                                    string userin = Console.ReadLine();
                                    if(book.seats.ContainsKey(userin))
                                    {
                                        book.setbooking(idinput, selectedid, userin);
                                        book.threadbooking();
                                        break;
                                        
                                    }
                                    else if(userin=="Q"||userin=="q")

                                    {
                                        bookingseatss = false;
                                    }
                                    else
                                    {
                                        Console.WriteLine("enter ID or exit with Q");
                                    }
                                    
                                    //int.TryParse(Console.ReadLine(), out int ticketno);

                                    //if (ticketno < 3)
                                    //{
                                    //    if (trainlst.ContainsKey(selectedid))
                                    //    {
                                    //        if (capcheck[selectedid] < trainlst[selectedid].maxcap)
                                    //        {


                                    //            bookinglst.Add(idinput, $"{trainlst[selectedid].id} {trainlst[selectedid].name} {ticketno}");
                                    //            Console.WriteLine(trainlst[selectedid].calculatetotal(ticketno));
                                    //            int v = capcheck[selectedid];
                                    //            v += ticketno;
                                    //            capcheck[selectedid] = v;

                                    //        }
                                    //        else
                                    //        {
                                    //            Console.WriteLine($"{trainlst[selectedid].maxcap - capcheck[selectedid]} number of seats is left please change the no. of seats");
                                    //        }
                                    //    }
                                    //}
                                }
                                break;
                            }
                        case "2":
                            {

                                book.checkbooking(idinput);
                                break;
                            }
                        case "q":
                            {
                                stay = false;
                                FileStream fs1 = new FileStream($"cusdic.txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter sw = new StreamWriter(fs1);
                                foreach (var d in cusdic)
                                {
                                    sw.WriteLine($"{d.Value.cusid},{d.Value.cusname},{d.Value.email},{d.Value.phonenumber}");
                                }
                                sw.Close();
                                fs1.Close();
                                FileStream fs2 = new FileStream($"traindic.txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter sw2 = new StreamWriter(fs2);
                                foreach(var d in trainlst)
                                {
                                    sw2.WriteLine($"{d.Value.id},{d.Value.name},{d.Value.maxcap},{d.Value.price}");
                                }
                                sw2.Close();
                                fs2.Close();
                                FileStream fs3 = new FileStream($"bookinglist.txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter sw3 = new StreamWriter(fs3);
                                foreach(var d in book.bookingls)
                                {
                                    sw.WriteLine($"{d.Key},{d.Value}");//cusid.bookingid,seatid
                                }
                                sw3.Close();
                                fs3.Close();
                                FileStream fs4 = new FileStream($"seatlist.txt", FileMode.OpenOrCreate, FileAccess.Write);
                                StreamWriter sw4 = new StreamWriter(fs4);
                                foreach (var d in book.seats)
                                {
                                    sw.WriteLine($"{d.Key},{d.Value}");//seatid,avail or no
                                }
                                sw4.Close();
                                fs4.Close();
                                break;

                            }
                        case "999":
                            {
                                
                                break;
                            }
                    }
                    


                }
                else
                {
                    Console.WriteLine("Enter Name");
                    string nameinput = Console.ReadLine();
                    Console.WriteLine("Enter phone number");
                    string phoneno = Console.ReadLine();
                    if (isvalidphoneno(phoneno))
                    {
                        Console.WriteLine("Enter email");
                        string email = Console.ReadLine();
                        if (IsValidEmail(email))
                        {

                            cusdic.Add(idinput, new customer(nameinput, idinput, email, phoneno));
                            Console.WriteLine("Account Created");
                        }
                        else
                        {
                            Console.WriteLine("Incorrent Email");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid phone no.");
                    }
                }

            }
        }
        /*Need To Design A Ticket Booking System . Conditions To Design 
•	Total Number Of Seats Allotted By The Admin
•	The User Need To Sign Up / Login To Book The Ticket , If The User Is Already Present Then It Need To Show A Message And Ask To Log In.
•	Maximum Number Of Seats One Can Book Is Not More Than 3.
•	User Must Have A Valid Phone Number And Emailid To Sign Up
•	Use Multi-Threading To Calculate Multiple Booking At A Time, But The Seat Number Has To Be Different . Otherwise, It Will Show An Error Message.
•	Admin Has the Access to See the Booking Details Of Every User Including The Payment Details.
         */
    }
}

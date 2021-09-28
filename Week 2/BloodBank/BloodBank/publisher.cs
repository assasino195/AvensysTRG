using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank
{
    //public delegate void EventHandler(string bloodtype, int count);
    class publisher
    {
        //List<string> lst = new List<string>();

        // List<string> lst1 = new List<string>();
        string A = "Blood Type A: 0";
        int bloodA;
        //public delegate void EventHandler(string bloodtype, int count);
        //public event EventHandler bloodadded;
        public EventHandler send;
        public string blood { get; set; }
        public int countofblood { get; set; }
        string output;
        //public publisher(string A, int b)
        //{
        //    blood = A;
        //    countofblood = b;
        //}
        //public string this[int i]
        //{
        //    get
        //    {
        //        return lst[i];
        //    }
        //    set
        //    {

        //        lst.Add(blood);
        //        send?.Invoke(this, null);

        //    }
        //}

        public void getinput(string blood,int countofblood)
        {
            this.blood = blood;
            this.countofblood = countofblood;
            if (blood == "A")
            {
                bloodA += countofblood;
                //foreach (string a in lst)
                //{
                //    if (a.Contains(blood))
                //    {
                //        string[] k = a.Split(' ');
                //        Console.WriteLine(a.Length);
                //        string lastindex = k[k.Length - 1];
                //        int temp = Int32.Parse(lastindex);
                //        countofblood += temp;
                //    }
                    //    string[] temp=A.Split(' ');
                    //int ofA = temp.Length-1;
                    //A = $"Blood Type A: {ofA + countofblood}";
                }
                //addbloodunit();

                output =$"total count of {blood} is { (bloodA.ToString())}";

                //lst.Add(output);
                //addbloodunit();

               // notify();
            }
        
        
        public void addbloodunit()
        {
            //if(blood=="a")
            //{
               //lst.Add(blood+countofblood.ToString());
            //}
            //foreach(string a in lst)
            //{
            //    if(a.Contains(blood))
            //    {
            //        string[] k = a.Split(' ') ;
            //        Console.WriteLine(a.Length);
                    
            //       int temp=Int32.Parse( k[k.Length-1]);
            //        countofblood += temp;
            //    }
            //}
        }
        //private void notify()
        //{
        //    send?.Invoke(blood, countofblood);
        //}

    
    }
}

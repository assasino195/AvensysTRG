using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_4_ses_1
{
    
    class publiseher
    {
        


        public event EventHandler<inteventargs> numbermodifiedevent;
        int input1;
        int input2;
        double interest;
        //public void getinput(int a)
        //{
        //    input1 = a;
            
        //    calculateint();
        //    inteventargs arg = new inteventargs(a);
        //    numbermodifiedevent(this, arg);
        //}
        public void startcalculate()
        {
            Console.WriteLine(interest);
        }
        public void calculateint(double principal, double interest,double months)
        {
            this.interest = (principal * interest * months) / 100;
            inteventargs argy = new inteventargs(this.interest);
            if (numbermodifiedevent != null)
            {
                numbermodifiedevent(this, argy);
            }
        }

        //public void dosmth(int a)
        //{
        //    a = a * a;
        //    inteventargs arg = new inteventargs(a);
        //    numbermodifiedevent(this, arg);
        //}
    }
}

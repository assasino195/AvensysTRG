using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week_5_exam
{
    class customer
    {
        public string name { get; set; }
        public string id { get; set; }
        public string chequeID { get; set; }
        public double cash { get; set; }
        public double loan { get; set; }
        
        public customer(string n,string id,double cash,double loan)
        {
           
                name = n;
                this.id = id;
                chequeID = (int.Parse(id) * 2).ToString();
                this.cash = cash;
            this.loan = loan;
               
           
          
        }
       public void deposit(double dep,string cID)
        {
            if(cID.Equals(chequeID))
            {
                cash += dep;
                Console.WriteLine($"You have Deposited {dep} and current balance is {cash}");
            }
            else
            {
                Console.WriteLine($"{cID} is not valid");
            }
        }
        public void withdraw(double with,string Cid)
        {
            if(Cid.Equals(chequeID))
            {
                if (cash > with)
                {
                    cash -= with;
                    Console.WriteLine($"You have withdrew {with} and your balance is now {cash}");
                }
                else
                {
                    Console.WriteLine("you do not have enough balance you only have "+cash);
                }
            }
            else
            {
                Console.WriteLine($"{Cid} is not valid");
            }
        }
        public void applyforloan(double amt,string cid)
        {
            if(chequeID.Equals(cid))
            {
                loan += amt;
                Console.WriteLine($"You have loaned {amt}.\nYour total Loan amount is {loan}");
            }
            else
            {
                Console.WriteLine("wrong cheque ID provided");
            }

            
        }


    }
}

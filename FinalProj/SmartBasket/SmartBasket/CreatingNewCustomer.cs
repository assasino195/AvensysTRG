using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    public class CreatingNewCustomer
    {
       
        public CreatingNewCustomer() { }
        public Customer createcustomer(string idinput,string nameinput,string email,string phoneno)
        {
           
            
            if (IsValidEmail(email))
            {
                
                if (isvalidphoneno(phoneno))
                {
                    //custDict.Add(idinput,
                    Customer temp= new Customer(idinput, nameinput, email, phoneno, "Member");
                    Console.WriteLine("Welcome to Super Market!");
                    return temp;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        public bool IsValidEmail(string email)
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
        public bool isvalidphoneno(string phoneno)
        {
            int count = 0;
            foreach (char a in phoneno)
            {
                if (count == 0)
                {
                    if (a == '8' || a == '9')
                    {

                    }
                    else
                    {
                        return false;
                    }
                }
                count++;
            }
            if (count == 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

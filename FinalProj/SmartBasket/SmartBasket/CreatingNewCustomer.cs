using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartBasket
{
    class CreatingNewCustomer
    {
        public Customer createcustomer(string idinput)
        {
            Console.WriteLine("Enter your name");
            string nameinput = Console.ReadLine();
            Console.WriteLine("Enter Your Email");
            string emailinput = Console.ReadLine();
            if (IsValidEmail(emailinput))
            {
                Console.WriteLine("Enter Your Phone No");
                string phonenoinput = Console.ReadLine();
                if (isvalidphoneno(phonenoinput))
                {
                    //custDict.Add(idinput,
                    Customer temp= new Customer(idinput, nameinput, emailinput, phonenoinput, "Member");
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

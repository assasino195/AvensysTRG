using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingCus_with_dict_and_file_append
{
    class Admin
    {
        Dictionary<string, customer> dictofcos = new Dictionary<string, customer>();
        public Admin()
        {
            if (!File.Exists("Banking_Details.txt"))
            {
                Console.WriteLine("No deta exist");
                return;
            }
            FileStream fs = new FileStream("Banking_Details.txt", FileMode.Open, FileAccess.Read);
            fs.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(fs);
            string str = sr.ReadLine();
            while (sr != null)
            {
                var strarr = str.Split('_');
                var account_bal = double.Parse(strarr[3]);
                var loan_applied = bool.Parse(strarr[5]);
                var customer = new customer(strarr[0], str[1], str[4], account_bal, loan_applied);
                if (!dictofcos.ContainsKey(strarr[0]))
                {
                    dictofcos.Add(strarr[0], customer);
                }
                str = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
        }
        public void performoperation()
        {
            bool user_exited = false;
            while(!user_exited)
            {
                Console.WriteLine("select option");
                Console.WriteLine("1.Create account");
                Console.WriteLine("2.Withdraw");
                int userinput = int.Parse(Console.ReadLine());
                switch(userinput)
                {
                    case 1:
                        {
                            var new_cust = accounthandling.accountopening();
                            if(new_cust!=null)
                            {
                                if(!dictofcos.ContainsKey(new_cust.customer_id))
                                {
                                    dictofcos.Add(new_cust.customer_id, new_cust);
                                }
                                else
                                {
                                    Console.WriteLine("Customer Account already exist");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Customer creation failed please try again");
                            }
                            break;
                        }
                    case 2:
                        {
                            var user_id = Console.ReadLine();
                            var customer = dictofcos[user_id];
                            Withdraw_Handling.Withdraw(customer);
                            break;
                        }
                    case 4:
                        {
                            writealltransactioninfile();
                            user_exited = true;
                            break;
                        }
                }
                
            }
        }

        private void writealltransactioninfile()
        {
            throw new NotImplementedException();
            
            //override existing file
            //write content of dictionary into the file
        }
    }
}

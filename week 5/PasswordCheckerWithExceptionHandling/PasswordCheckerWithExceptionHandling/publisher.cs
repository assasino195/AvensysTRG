using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PasswordCheckerWithExceptionHandling
{

    class publisher
    {
        public delegate void eventhandler(string s);
        public event eventhandler send;
        string output;
        string input;
        public void getinput(string input)
        {
            this.input = input;
            check();
            if(send!=null)
            {
                send(output);
            }
        }
        public static bool Contains(string target, string list)
        {
            return target.IndexOfAny(list.ToCharArray()) != -1;
        }
        private static bool CheckInvalidInput(string stringToCheck, IEnumerable<char> allowedChars)
        {
            return stringToCheck.All(allowedChars.Contains);
        }
        public void check()
        {
            char temp = ' ';
            //char temp2 = ' ';
            int count = 0;
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = uppercase.ToLower();
            string digits = "123456789";
            string special = " ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; ";
            var allowedchars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+=-[]{}";
            bool okay = CheckInvalidInput(input, allowedchars);
            if (okay == false)
            {
                output="Your password contained characters that are not allowed";
            }
            if (Contains(input, lowercase) && Contains(input, uppercase) && Contains(input, digits))
            {

            }
            else
            {
                okay = false;
            }
            foreach (char a in input)
            {
                if (temp == a)
                {
                    count++;
                }
                else
                {
                    count = 0;
                }
                if (count > 1)
                {
                    okay = false;
                    output = "Passoword contained multiple iteration of same character eg. aaa max=2";
                }
                temp = a;



            }


            if (okay == true)
            {
                output = "password accepted";

            }
            else
            {
                output = "password not accepted";
            }
        }

    }
}

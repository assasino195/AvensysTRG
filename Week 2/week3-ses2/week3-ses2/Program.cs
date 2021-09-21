using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week3_pretest_practice
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("CALCULATOR");
            Console.WriteLine("1 Addition:");
            Console.WriteLine("2: Subtraction");
            Console.WriteLine("3: Division");
            Console.WriteLine("4: Multiplication");
            Console.WriteLine("5: Modulation");
            Console.WriteLine("6: EXIT");

        }
        static void calculatorapp()
        {
            calculatorclass cal = new calculatorclass();

            int tempA;
            int tempB;


            bool stay = true;
            while (stay)
            {
                menu();
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1: //ADD
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} + {tempB} = {cal.add(tempA, tempB)}");

                            break;
                        }
                    case 2: //subtract
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} - {tempB} = {cal.subtract(tempA, tempB)}");
                            break;

                        }
                    case 3:// divide
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} / {tempB} = {cal.divide(tempA, tempB)}");
                            break;
                        }
                    case 4://multiply
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} * {tempB} = {cal.multiply(tempA, tempB)}");
                            break;
                        }
                    case 5://modulate
                        {
                            Console.WriteLine("Please enter your first digit");
                            tempA = Int32.Parse(Console.ReadLine());
                            Console.WriteLine("Please enter your Second digit");
                            tempB = Int32.Parse(Console.ReadLine());
                            Console.WriteLine($"Addition between {tempA} % {tempB} = {cal.modulus(tempA, tempB)}");
                            break;
                        }
                    case 6:
                        {
                            stay = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Please enter a valid option no.");
                            break;
                        }
                }
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
        static void passwordcheck()
        {

            //int smallletter = 0;
            //int bigletter = 0;
            //int valid = 0;

            char temp = ' ';
            //char temp2 = ' ';
            int count = 0;
            string uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string lowercase = uppercase.ToLower();
            string digits = "123456789";
            string special = " ! @ # $ % ^ & * ( ) + = _ - { } [ ] : ; ";
            var allowedchars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!@#$%^&*()+=-[]{}";

            Console.WriteLine("Please create your password");
            string input = Console.ReadLine();

            bool okay = CheckInvalidInput(input, allowedchars);
            if (okay == false)
            {
                Console.WriteLine("Your password contained characters that are not allowed");
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
                    Console.WriteLine("Passoword contained multiple iteration of same character eg. aaa max=2");
                }
                temp = a;



            }


            if (okay == true)
            {
                Console.WriteLine("password accepted");

            }
            else
            {
                Console.WriteLine("password not accepted");
            }
            Console.WriteLine();

            //if (Contains(input, lowercase) && Contains(input,uppercase) && Contains(input,digits) )
            //    {
            //        valid = 1;
            //    }
            //if(Contains(input,special))
            //{
            //    valid = 1;
            //}
            //else

            //if (valid == 1)
            //{
            //    Console.WriteLine("password accepted");

            //}
            //else
            //{
            //    Console.WriteLine("password denied");
            //}
            //if(5 < input.Length && 25>input.Length)
            //{
            //    foreach(char a in input)
            //    {

            //        if(a>='a' && a<='z' )
            //        {


            //            if (a >= 'A' && a <= 'Z')
            //            {
            //                bigletter++;
            //                if (a >= '0' && a <= '9')
            //                {

            //                    okay = true;
            //                    if (a == temp && input[a + 1] == temp)
            //                    {
            //                        okay = false;
            //                        Console.WriteLine("iteration of 3 characters");
            //                        break;
            //                    }
            //                    else
            //                    {
            //                        okay = true;
            //                        break;
            //                    }

            //                }
            //            }
            //        }

            //    }

            //}
            //    if (okay == false)
            //    {
            //        Console.WriteLine("please re-enter your password");
            //    }
            //    else
            //    {
            //        Console.WriteLine("password accepted");
            //    }
            //    Console.WriteLine($"small letter{smallletter}: Big letter{bigletter}");
        }
        static bool isPrime(int n)
        {
            // Corner case
            if (n <= 1)
                return false;

            // Check from 2 to n-1
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }
        static int ReverseInteger(int start)
        {
            var reverse = string.Join("", Math.Abs(start).ToString().Reverse());
            return int.Parse(reverse) * Math.Sign(start);
        }
        static void primeno()
        {
            int temp = 0;
            Stack<int> listsint = new Stack<int>();
            for(int i=0;i<100;i++)
            {
                if(isPrime(i)==true)
                {
                    temp=ReverseInteger(i);
                    if(isPrime(temp)==true)
                    {
                        listsint.Push(i);
                    }
                    
                }
            }
            foreach(int a in listsint)
            {
                Console.WriteLine(a);
            }
        }
        static void time()
        {
            Console.WriteLine("Enter the date you joined");
            
            DateTime current = DateTime.UtcNow;
            DateTime sgtime = TimeZoneInfo.ConvertTimeFromUtc(current, TimeZoneInfo.FindSystemTimeZoneById("Singapore Standard Time"));
            Console.WriteLine("enter join date");
            DateTime joindate = DateTime.Parse(Console.ReadLine());
            //string[] joindate = Console.ReadLine().Split('/');
            Console.WriteLine($"{(sgtime-joindate).TotalSeconds}");

            //DateTime Joineddate = new DateTime(joindate(0),));

        }
        static void hexstring()
        {
            Console.WriteLine("enter a string");
            string input = Console.ReadLine();
            string validinput = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFHIJKLMNOPQRSTUVWXYZ#";
            bool checker = CheckInvalidInput(input, validinput);
            if (checker == false)
            {
                Console.WriteLine("is false as it contains values that does not consist of allowed characters");
            }
            else
            {
                if (input.StartsWith("#") && input.Length == 6)
                {
                    Console.WriteLine("VALID HEX CODE"+input);

                }
                else
                {
                    Console.WriteLine("invalid HEX CODE");
                }
            }
        }
            class manupilateobj
            {
                public object Manupilate(object obj)
                {
                    if(obj is string str)
                    {
                        char[] charArray = str.ToCharArray();
                        Array.Reverse(charArray);
                        return charArray;
                    }
                    else if(obj is int intt)
                    {
                        return intt*intt;
                    }
                    else if(obj is double dbl)
                    {
                        return (((decimal)dbl).ToString());
                    }
                    else
                    {
                        return "not supported";
                    }
                }
            }
            static void manuobj()
            {
                manupilateobj manu = new manupilateobj();

                Console.WriteLine("enter your value");
            var manuu = Console.ReadLine();

                Console.WriteLine(manu.Manupilate(manuu));

            }
        static void hcflcm()
        {
            Console.WriteLine("Enter 1st integer");
            int a = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter 2nd integer");
            int b = Int32.Parse(Console.ReadLine());
            int temp0,temp1, temp2, gcf, lcm;
            temp1 = a;
            temp2 = b;
            while(temp2!=0)
            {
                
                temp0 = temp2;
                temp2 = temp1 % temp2;
                temp1 = temp0;
            }
            gcf = temp1;
            lcm = ((a * b) / gcf);
            Console.WriteLine($"GCF of {a} & {b} is: {gcf}");
            Console.WriteLine($"LCM of {a} & {b} is {lcm}");
        }
        static void printstring()
        {
            Console.WriteLine("Enter your sentence");
            string[] a = Console.ReadLine().Split(' ') ;
            int count = 0;
            foreach(string i in a)
            {
                count++;
                Console.WriteLine(i);
            }
            
            Console.WriteLine("total words in sentence: "+count);
        }
        static void searchstring()
        {
            int count = 0;
            Console.WriteLine("Enter Sentence");
            string[] a = Console.ReadLine().Split(' ');
            Console.WriteLine("Enter word to find occurance for");
            string b = Console.ReadLine();
            foreach(string i in a)
            {
                if(i==b)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
        static char NextLetter(char letterIn)
        {
            int a = (int)letterIn + 1;

            char ret;
            //if (char.IsLetterOrDigit((char)a))
                ret = ((char)a);
            //else
            //{
            //    ret = NextLetter((char)a);
            //}
            return ret;
        }
        static void replacecharinstring()
        {
            Console.WriteLine("Enter your word/sentence");
            string letters = "abcdefghijklmnopqrstuvwxyz";
            string a = Console.ReadLine().ToLower();
            foreach(char i in a)
            {
                Console.Write(NextLetter(i));
            }
            //foreach(char i in a)
            //{
            //    foreach(char k in letters)
            //    {
            //        if(k=='z')
            //        {
            //            Console.Write('a');
            //        }
            //        else if(i==k)
            //        {
            //            Console.Write((int)letters+1);
            //            break;
            //        }
            //    }
                
            //}
        }
        [Flags]
        enum lista
        {
            a=10,
            b=11,
            c=12,
            d=13,
            e=14,
            f=15
        }
        static void int2hex2binary()
        {
            Console.WriteLine("enter integer number to be converted");
            int input = Int32.Parse(Console.ReadLine());
            //string hex = input.ToString("X");
            //string bin = Convert.ToString(input, 2);

            //Console.WriteLine($"Input number={input}\nHexadecimal conversion: {hex}\nBinary conversion: {bin}");
            //int temp1 = input;
            int temp2 = input;
            Stack<string> a = new Stack<string>();
            //Console.WriteLine(temp1);
            //Console.WriteLine(temp2);
            string hexValue = string.Empty;
            for (int i = input; i > 0; i =i/ 16)
            {
                int j = i % 16;
                if (j > 9)
                {
                    switch (j)
                    {
                        case 10:
                            {
                                hexValue = "A" + hexValue;
                                //a.Push("A");
                                break;
                            }
                        case 11:
                            {
                                hexValue = "B" + hexValue;
                                //a.Push("B");
                                break;
                            }
                        case 12:
                            {
                                hexValue = "C" + hexValue;
                                //a.Push("C");
                                break;
                            }
                        case 13:
                            {
                                hexValue = "D" + hexValue;
                                //a.Push("D");
                                break;
                            }
                        case 14:
                            {
                                hexValue = "E" + hexValue;
                                //a.Push("E");
                                break;
                            }
                        case 15:
                            {
                                hexValue = "F" + hexValue;
                                //a.Push("F");
                                break;
                            }
                    }
                }
                else if (j > 0)
                {
                    hexValue = j.ToString() + hexValue;
                    //a.Push(j.ToString());
                }
            }
            //while (temp2 > 0)
            //{
            //    int temp1 = temp2 % 16;
            //    temp2 = temp2 / 16;
            //    if (temp1 > 9)
            //    {
            //        switch (temp1)
            //        {
            //            case 10:
            //                {
            //                    a.Push("A");
            //                    break;
            //                }
            //            case 11:
            //                {
            //                    a.Push("B");
            //                    break;
            //                }
            //            case 12:
            //                {
            //                    a.Push("C");
            //                    break;
            //                }
            //            case 13:
            //                {
            //                    a.Push("D");
            //                    break;
            //                }
            //            case 14:
            //                {
            //                    a.Push("E");
            //                    break;
            //                }
            //            case 15:
            //                {
            //                    a.Push("F");
            //                    break;
            //                }
            //        }
            //    }
            //    else if (temp1 > 0)
            //    {
            //        a.Push(temp1.ToString());
            //    }
            //}
            Console.Write("HEXADECIMAL: " + hexValue);
            //foreach (string k in a)
            //{
                
            //    Console.Write(k);
            //}
            Console.WriteLine();

            int temp;
            int[] arr = new int[10];
            for (temp = 0; input > 0; temp++)
            {
                arr[temp] = input % 2;
                input = input / 2;
            }
            Console.Write("Binary of the given number= ");
            for (temp = temp - 1; temp >= 0; temp--)
            {
                Console.Write(arr[temp]);
            }
        }
        static void degree2shaep()
        {
            Console.WriteLine("Enter the no. of inputs");
            int Noinput = Int32.Parse(Console.ReadLine());
            switch(Noinput)
            {
                case 1:
                    {
                        Console.WriteLine("Enter degree");

                        break;
                    }
            }
        }
        static void menus()
        {
            Console.WriteLine("1.q1 password check");
            Console.WriteLine("2.q2 add prime number from 1-100+reverse the numbere");
            Console.WriteLine("3.q3 calculator app");
            Console.WriteLine("4.q4 total amount of seconds since join date");
            Console.WriteLine("5.q5 hex string checker");
            Console.WriteLine("6.exit");
            Console.WriteLine("7.q7 manupilate object");
            Console.WriteLine("8.q8 finding highest common factor and lowest common multiple");
            Console.WriteLine("9.q9 finding the count of words in a setence");
            Console.WriteLine("10.q10 finding if a sentence contains a certain word");
            Console.WriteLine("11.q11 Shape base on input");
            Console.WriteLine("12.q12 Replace characters with +1 count of it");
            Console.WriteLine("13.q13 convert int to hex & binary");
        }
        static void Main(string[] args)
        {
            bool stay = true;
            while(stay)
            {
                menus();
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            passwordcheck();
                            Console.WriteLine();
                            break;
                        }
                    case "2":
                        {
                            primeno();
                            Console.WriteLine();
                            break;
                        }
                    case "3":
                        {
                            calculatorapp();
                            Console.WriteLine();
                            break;
                        }
                    case "4":
                        {
                            time();
                            Console.WriteLine();
                            break;
                        }
                    case "5":
                        {
                            hexstring();
                            Console.WriteLine();
                            break;
                        }
                    case "6":
                        {
                            stay = false;
                            break;
                        }
                    case "7":
                        {
                            manuobj();
                            Console.WriteLine();
                            break;
                        }
                    case "8":
                        {
                            hcflcm();
                            break;
                        }
                    case "9":
                        {
                            printstring();
                            Console.WriteLine();
                            break;
                        }
                    case "10":
                        {
                            searchstring();
                            Console.WriteLine();
                            break;
                        }
                    case "11":
                        {

                            break;
                        }
                    case "12":
                        {
                            replacecharinstring();
                            Console.WriteLine();
                            Console.WriteLine();
                            break;
                        }
                    case "13":
                        {
                            int2hex2binary();
                            Console.WriteLine();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("enter a valid option");
                            Console.WriteLine();
                            break;
                        }

                }
            }
            //passwordcheck();
           
            //Console.ReadLine();
            /*write a program to find a prime number between 1 to 100 , then reverse the number if the reverse number is also a prime one , then store the number

            find out the total number of days and sessions you have joined till now then convert the total time into seconds.
            Using boxing and unboxing concept

            5.write a program  that determines whether a string is a valid hex code .A hex code must begin with a pound key # and is exactly 6 characters in length. 
            Each character must be a digit from 0-9 or an alphabetic character from A-F. All alphabetic characters may be uppercase or lowercase.
            (use inheritance concept)
            */
        }
    }
}

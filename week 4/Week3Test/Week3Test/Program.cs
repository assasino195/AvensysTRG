using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week3Test
{
    class Program
    {
        static void menu()
        {
            Console.WriteLine("Questions");
            Console.WriteLine("1: Q1 LOTERRY WINNER)");
            Console.WriteLine("2: Q2 Delegate Ops ");
            Console.WriteLine("3: Q3 Timer");
            Console.WriteLine("4: Q6 Exception Handling");
            Console.WriteLine("5: EXIT");

        }
        public static string selectwinner()
        {
            System.Random random = new System.Random();
            string temp = string.Empty;
            for (int i = 0; i < 6; i++)//to test change to 1
            {
                string chars = "abcdefghijk";
                string no = "0123456789";
                string temps = string.Empty;
                int num = random.Next(9);
                temp += no[num];
                temp += chars[num];

            }
            return temp;
        }
        static void q1()
        {


            List<string> names = new List<string>();
            List<string> nos = new List<string>();
            System.Random random = new System.Random();
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("1. Buy New Lottery Ticket");
                Console.WriteLine("2. Display all tickets purchased");
                Console.WriteLine("3. generate winner");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter Name");
                            string inputname = Console.ReadLine();
                            string chars = "abcdefghijk";
                            string no = "0123456789";
                            string temp = string.Empty;
                            for (int i = 0; i < 6; i++)//to test this change this loop to 1 and change generate winner to 1
                            {
                                string temps = string.Empty;
                                int num = random.Next(9);
                                temp += no[num];
                                temp += chars[num];

                            }
                            Console.WriteLine(temp);
                            if (nos.Count == 0)
                            {
                                nos.Add(temp);
                                names.Add(inputname);
                            }
                            else
                            {
                                //for(int i=0;i<nos.Count;i++)
                                //  {
                                if (nos.Contains(temp))
                                {
                                    Console.WriteLine("Regenerate another");
                                    break;
                                }
                                else
                                {
                                    nos.Add(temp);
                                    names.Add(inputname);
                                    Console.WriteLine("Added Numbers");

                                }
                                // }
                                //foreach (string i in nos)
                                //{
                                //    Console.WriteLine(i);
                                //}
                            }
                            break;
                        }
                    case "2":
                        {
                            int count = 0;
                            foreach (string a in names)
                            {
                                Console.WriteLine($"Name: {a}");
                                Console.WriteLine($"Lottery No. :{nos[count]}");
                                count++;
                            }
                            break;
                        }
                    case "3":
                        {
                            int count = 0;
                            string winner = selectwinner();
                            if (nos.Contains(winner))
                            {

                                foreach (string a in nos)
                                {
                                    if (a == winner)
                                    {
                                        Console.WriteLine("WINNER FOUND!");
                                        Console.WriteLine($"Name: {names[count]}");
                                        Console.WriteLine($"Ticket: {a}");
                                    }
                                    else { count++; }

                                }
                            }
                            else
                            {
                                Console.WriteLine("no winners for this lottery");
                            }
                            break;
                        }
                    case "4":
                        {
                            stay = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("invalid option please try again");
                            break;
                        }
                }
            }


            //int num = random.Next(9);

            //int a=Int32.Parse(Console.ReadLine());

        }
        private static void q2()
        {
            Math operationCalculator = new Math();
            EventHandlerOperation add = new EventHandlerOperation(Math.Add);
            EventHandlerOperation sub = new EventHandlerOperation(Math.Min);
            EventHandlerOperation multi = operationCalculator.Times;
            EventHandlerOperation divi = new EventHandlerOperation(operationCalculator.Div);
            EventHandlerOperation all = add + sub + multi + divi;
            Console.WriteLine("enter first digit");
            int input1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("enter second digit");
            int input2 = Int32.Parse(Console.ReadLine());
            add.Invoke(input1, input2);
            all.Invoke(input1, input2);



        }
        public static void q3()
        {
            bool stay = true;
            while (stay)
            {
                timer timers = new timer();
                maintimer mt = new maintimer(false);
                Console.WriteLine("Timer Start? Y/N");
                // int count = 0;
                string input = Console.ReadLine().ToUpper();
                for (int i = 0; i < 5; i++)
                {
                    if (input == "Y")
                    {

                        // timers.timerstart();
                        mt.isCounterRunning = true;


                    }
                    else if (input == "N")
                    {
                        mt.isCounterRunning = false;
                        stay = false;

                    }
                    else
                    {
                        Console.WriteLine("reinput");
                    }
                    if (mt.isCounterRunning == true)
                    {
                        timers.timerstart();
                    }
                    else
                    {
                        timers.displaycounter();
                        break;
                    }
                    
                    //count++;
                    //if (count == 5)
                    //{
                    //    Console.WriteLine("stop counter? Y/N");
                    //    string exit = Console.ReadLine().ToUpper();
                    //    if (exit == "Y")
                    //    {
                    //        stay = false;
                    //    }
                    //}
                }

            }
        }
        public static void q6()
        {
            exceptionhandling ecp = new exceptionhandling();

            Console.WriteLine("Enter no. from 0-9 to get index");
            ecp.getElementInt(Console.ReadLine());
            Console.WriteLine("Enter first digit for dividing");
            string a = Console.ReadLine();
            Console.WriteLine("enter 2nd digit for dividing");
            string b = Console.ReadLine();
            ecp.dividingtest(a, b);
            Console.WriteLine("Enter String");
            string input = Console.ReadLine();
            Console.WriteLine("Enter index you wish to call");
            int input1 = Int32.Parse(Console.ReadLine());
            ecp.arrcheck(input, input1);

        }
        static void Main(string[] args)
        {
            bool stay = true;
            while (stay)
            {
                menu();
                int input = Int32.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        {
                            q1();
                            break;
                        }
                    case 2:
                        {
                            q2();
                            break;

                        }
                    case 3:
                        {
                            q3();
                            break;
                        }
                    case 4:
                        {
                            q6();
                            break;
                        }
                    case 5:
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
            Console.ReadLine();
        }
    }
}


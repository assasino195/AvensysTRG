using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace week4_ses2
{
    class Program
    {
        public delegate void e(object input1, object input2);
        class exceptionhandling
        {

            class addition
            {

                public void add(object a, object b)
                {
                    try
                    {
                        int a1 = Int32.Parse((string)a);
                        int a2 = Int32.Parse((string)b);
                        Console.WriteLine($"{a1} + {a2} = {a1 + a2}");
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"Invalid cast detected {ex}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FORMAT Eception raised {ex}");
                        Console.WriteLine("Please only enter numbers");
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine($"Null Eception raised {ex}");
                    }
                    finally
                    {
                        Console.WriteLine();
                    }

                }
            }
            class subtraction
            {
                public void sub(object a, object b)
                {
                    try
                    {
                        int a1 = Int32.Parse((string)a);
                        int a2 = Int32.Parse((string)b);
                        Console.WriteLine($"{a1} + {a2} = {a1 + a2}");
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"Invalid cast detected {ex}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FORMAT Eception raised {ex}");
                        Console.WriteLine("Please only enter numbers");
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine($"Null Eception raised {ex}");
                    }
                    finally
                    {
                        Console.WriteLine();
                    }
                }
            }





        }
        class multiply
        {
            public void multi(object a, object b)
            {
                try
                {
                    int a1 = Int32.Parse((string)a);//cannot hear u
                    int a2 = Int32.Parse((string)b);
                    Console.WriteLine($"{a1} * {a2} = {a1 * a2}");
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Invalid cast detected {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                    Console.WriteLine("Please only enter numbers");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Null Eception raised {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Eception raised {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Over flowed {ex.Message}");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
        class divide
        {
            public void divi(object a, object b)
            {
                try
                {
                    int a1 = Int32.Parse((string)a);
                    int a2 = Int32.Parse((string)b);
                    Console.WriteLine($"{a1} / {a2} = {a1 / a2}");
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine($"Invalid cast detected {ex.Message}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                    Console.WriteLine("Please only enter numbers");
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine($"Null Eception raised {ex.Message}");
                }
                catch (DivideByZeroException ex)
                {
                    Console.WriteLine($"Eception raised {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Over flowed {ex.Message}");
                }
                finally
                {
                    Console.WriteLine();
                }
            }
        }
        public static void q1()
        {
            Console.WriteLine("enter first digit");
            object a = Console.ReadLine();
            Console.WriteLine("enter 2nd digit");
            object b = Console.ReadLine();
            multiply multi = new multiply();
            divide divi = new divide();
            e delegateException = new e(multi.multi);
            delegateException += divi.divi;
            //Exception multii = new Exception(multi.multi);
            //Exception divii = new Exception(divi.divi);
            //Exception output = divii+ multii;
            delegateException.Invoke(a, b);
            //divi.divi(a, b);
            // multi.multi(a, b);


        }
        public static void q2()
        {
            Console.WriteLine("Enter text name");
            string filename = Console.ReadLine();
            Console.WriteLine("enter string you wish to save to a file");
            string input = Console.ReadLine();
            string dir = "";//@"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 4\week4 ses2\test";
            try
            {
                Directory.CreateDirectory(dir);//create folder in location if its does not exist
                File.WriteAllText(filename, input);
            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine($"Null Eception raised {ex.Message}");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Path cannot be empty {e.Message}");
            }
            catch (PathTooLongException ex)
            {
                Console.WriteLine($"Path too long {ex.Message}");
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine($"Directory not found {e}");
            }
            catch (NotSupportedException )
            {
                Console.WriteLine($"not supproted exception");
            }
            catch (IOException e)
            {
                Console.WriteLine($"Io exception {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"GENERAL EXCEPTION! {e}");
            }


        }
        static void q3()
        {
            Stack<int> stacky = new Stack<int>();
            stacky.Push(10);
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("1.Push to stack\n2.Pop from stack\n3.Display");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.WriteLine("Enter digit you wish to push into stack");
                    object a = Console.ReadLine();
                    try
                    {
                        int trying = int.Parse((string)a);
                        stacky.Push(trying);
                        Console.WriteLine($"{trying} has been pushed into stack");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                    }
                    catch (NullReferenceException ex)
                    {
                        Console.WriteLine($"Null Eception raised {ex.Message}");
                    }
                    catch (InvalidCastException ex)
                    {
                        Console.WriteLine($"Invalid cast detected {ex.Message}");
                    }

                }
                else if (input == "2")
                {
                    try
                    {
                        int popped = stacky.Pop();
                        Console.WriteLine($"{popped} has been popped and removed from stack");
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Indexer out of range exception raised {ex.Message}");
                    }
                    catch (InvalidOperationException e)
                    {
                        Console.WriteLine($"Stack is empty {e.Message}");
                    }
                }
                else if (input == "3")
                {
                    foreach (int a in stacky)
                    {
                        Console.WriteLine(a);
                    }
                }
                else
                {
                    stay = false;
                }


            }
        }
        static void q4()
        {
            int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            bool stay = true;
            while (stay)
            {
                Console.WriteLine();
                Console.WriteLine($"1: Set value of an index\n2.: display value of an index\nDisplay all values in Array\nany other button to quit");
                string input = Console.ReadLine();
                if (input == "1")
                {
                    Console.Write("Enter the value you wish to store: ");
                    string k = Console.ReadLine();
                    Console.Write("enter the position you wish to store it at: ");
                    string o = Console.ReadLine();
                    try
                    {
                        int indexer = int.Parse((string)o);
                        int value = int.Parse((string)k);
                        arr[indexer] = value;
                        Console.WriteLine($"{value} has been set at {indexer}");
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine($"Argument Null Exception caught: {e}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"Over flowed {ex.Message}");
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Indexer out of range exception raised {ex.Message}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("EXCEPTION CAUGHT!");
                    }

                }
                else if (input == "2")
                {
                    Console.WriteLine("enter the index you wsh to access from 0-9");
                    object a = Console.ReadLine();
                    try
                    {
                        int indexer = int.Parse((string)a);
                        //nsole.Write("The number you asked for is: ");
                        Console.WriteLine($"The number you asked for is: {arr[indexer]}");
                    }
                    catch (ArgumentNullException e)
                    {
                        Console.WriteLine($"Argument Null Exception caught: {e}");
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                    }
                    catch (OverflowException ex)
                    {
                        Console.WriteLine($"Over flowed {ex.Message}");
                    }
                    catch (IndexOutOfRangeException ex)
                    {
                        Console.WriteLine($"Indexer out of range exception raised {ex.Message}");
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("EXCEPTION CAUGHT!");
                    }
                }
                else if (input == "3")
                {
                    foreach (int a in arr)
                    {
                        Console.WriteLine(a);
                    }
                }
                else
                {
                    stay = false;
                }
            }

        }
        class customer
        {
            List<string> list = new List<string>();
            public event EventHandler dataAdded;
            string name { get; set; }
            int id { get; set; }
            string addr { get; set; }
            string output;
            public string this[int i]
            {
                get
                {
                    return list[i];
                }
                set
                {

                    list.Add(output);
                    dataAdded?.Invoke(this, null);
                }
            }
            public void getinput(string name, int id, string addr)
            {
                //this.name = name;
                //this.id = id;
                //this.addr = addr;
                output = $"Name: {name}\nID: {id}\nAddress: {addr}";
                //tput = name + id.ToString() + addr;
                list.Add(output);
            }

        }
        class store
        {
            private customer cus;
            public void subscribetoevent(customer cus)
            {
                this.cus = cus;
                cus.dataAdded += Cus_dataAdded;
            }

            private void Cus_dataAdded(object sender, EventArgs e)
            {
                Console.WriteLine($"{sender} added to list");
            }


        }



        public static void q5()
        {
            customer cs = new customer();
            store s = new store();
            s.subscribetoevent(cs);
            int count = 0;
            Console.WriteLine($"1.Search Customer Name: \n2.Display all customer name: \n3.Add new customer");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    {

                        break;
                    }
                case "2":
                    {
                        for (int i = 0; i < count; i++)
                        {
                            Console.WriteLine(cs[i]);
                        }
                        break;
                    }
            }
            Console.WriteLine("Enter ur name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter your ID");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Address: ");
            string addr = Console.ReadLine();
            cs.getinput(name, id, addr);

        }
        class Customer1
        {
            public string name { get; private set; }
            public int id { get; private set; }
            public string addr { get; private set; }
            public Customer1(object name, object id, object addr)
            {
                try
                {


                    this.name = name.ToString();
                    this.id = int.Parse((string)id);
                    this.addr = addr.ToString();
                }
                catch (ArgumentNullException e)
                {
                    Console.WriteLine($"Argument Null Exception caught: {e}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine($"Over flowed {ex.Message}");
                }
                catch (Exception e)
                {
                    Console.WriteLine($"EXCEPTION CAUGHT! {e.Message}");
                }
            }

            public string print()
            {
                return $"Name: {name} \nID: {id} \nAddress: {addr}";
            }



        }
        public static void q6()
        {
            List<string> lst1 = new List<string>();
            List<object> list = new List<Object>();
            bool stay = true;
            string tested = string.Empty;
            int i = 0;
            while (stay)
            {
                Console.WriteLine($"1.Add new Customer\n2.Search for customer\n3.Display all customers");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        {
                            Console.WriteLine("Enter your Name: ");
                            object name = Console.ReadLine();
                            Console.WriteLine("Enter ID:");
                            object id = Console.ReadLine();
                            Console.WriteLine("enter address");
                            object addr = Console.ReadLine();
                            Customer1 cus = new Customer1(name, id, addr);
                            list.Add(cus);
                            lst1.Add(cus.print());
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine($"To search for customer data pick an option\n1.Search by Name\nSearch by ID");
                            string opt = Console.ReadLine();
                            if (opt == "1")
                            {
                                Console.WriteLine("Enter your Name: ");
                                object n = Console.ReadLine();
                                try
                                {
                                    string namee = n.ToString();
                                    foreach (string a in lst1)
                                    {
                                        string[] k = a.Split(' ');
                                        foreach (string o in k)
                                        {

                                            if (namee == o)
                                            {
                                                Console.WriteLine(a);
                                            }



                                        }
                                    }
                                }
                                catch (ArgumentNullException e)
                                {
                                    Console.WriteLine($"Argument Null Exception caught: {e}");
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                                }
                                catch (OverflowException ex)
                                {
                                    Console.WriteLine($"Over flowed {ex.Message}");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine($"EXCEPTION CAUGHT!");
                                }
                            }
                            else
                            {

                                Console.WriteLine("Enter ID:");
                                object d = Console.ReadLine();


                                try
                                {
                                    i = int.Parse((string)d);
                                    tested = i.ToString();

                                }
                                catch (ArgumentNullException e)
                                {
                                    Console.WriteLine($"Argument Null Exception caught: {e}");
                                }
                                catch (FormatException ex)
                                {
                                    Console.WriteLine($"FORMAT Eception raised {ex.Message}");
                                }
                                catch (OverflowException ex)
                                {
                                    Console.WriteLine($"Over flowed {ex.Message}");
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine($"EXCEPTION CAUGHT!");
                                }
                                finally
                                {
                                    bool found = false;
                                    foreach (string a in lst1)
                                    {
                                        string[] k = a.Split(' ');
                                        foreach (string o in k)
                                        {

                                            if (tested == o)
                                            {
                                                if (o == "ID:")
                                                {
                                                    Console.WriteLine(a);
                                                    Console.WriteLine();
                                                    found = true;
                                                }
                                            }



                                        }
                                    }
                                    if (!found)
                                    {
                                        Console.WriteLine("User not found");
                                    }
                                }

                            }

                            break;
                        }


                    case "3":
                        {
                            foreach (string a in lst1)
                            {
                                Console.WriteLine(a);
                            }
                            break;
                        }
                    default:
                        {
                            stay = false;
                            break;
                        }
                }




            }
        }

        public static void q8()
        {
            int[] arr = new int[10] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            string a = "a b c d e f g h i o";
            string[] arr1 = a.Split(' ');
            Predicate<int> arrcheck = (input) =>
              {
                  bool found = false;
                  foreach (int i in arr)
                  {
                      if (input == i)
                      {
                          found = true;
                      }

                  }
                  return found;
              };
            Predicate<string> strarrcheck = (input1) =>
              {
                  bool found = false;
                  foreach (string k in arr1)
                  {
                      if (input1 == k)
                      {
                          found = true;
                      }
                  }
                  return found;
              };
            Console.WriteLine("enter number to check");
            int no = int.Parse(Console.ReadLine());
            Console.WriteLine($"is number in Array? {arrcheck(no)}");
            Console.WriteLine();
            Console.WriteLine("enter string to check");
            string letter = Console.ReadLine();
            Console.WriteLine($"Is letter in Array? {strarrcheck(letter)}");
        }


        class q10class
        {
            public event EventHandler<q10eventargs> q10operationeventchecker;
            public void calq10(object a, object b)
            {

                q10eventargs q10 = new q10eventargs(a, b);
                if (q10operationeventchecker != null)
                {
                    q10operationeventchecker(this, q10);
                }
            }
        }
        class samevaluexception : Exception
        {
            public samevaluexception() { Console.WriteLine(base.Message); }
            public samevaluexception(string valueexcpetion) : base(string.Format("Enter two different values" + valueexcpetion))
            {
               
            }
        }
        class q91
        {
            public int c { get; private set; }
            public q91(int a, int b)
            {
                c = a + b;
            }
        }
        public static void Q9()
        {
            Console.WriteLine("enter first digit");
            object a = Console.ReadLine();
            Console.WriteLine("enter Second digit");
            object b = Console.ReadLine();
            int a1 = 0; ;
            int a2 = 0; ;

            try
            {
                a1 = int.Parse(a.ToString());
                a2 = int.Parse(b.ToString());
                if (a1 != a2)
                {
                    q91 q = new q91(a1, a2);
                    Console.WriteLine(q.c);
                }
                else
                {
                    throw (new samevaluexception($" instead of {a1} & {a2}"));
                }


            }
            catch (samevaluexception e)
            {
                Console.WriteLine(e.Message.ToString());


            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine($"Argument null caught: " + e.Message);
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Format exception caught: {e.Message}");
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"Over flow exception caught: {e.Message}");
            }
           
           


            //q9class q9c = new q9class();
            //q9c.q9operandcheckerevent += Q9c_q9operandcheckerevent;
            //q9c.calq9(a, b);



        }
        static void q10()
        {
            Console.WriteLine("enter first digit");
            object a = Console.ReadLine();
            Console.WriteLine("enter Second digit");
            object b = Console.ReadLine();
            q10class q10 = new q10class();
            q10.q10operationeventchecker += Q9c_q9operandcheckerevent;
            q10.calq10(a, b);
        }


        private static void Q9c_q9operandcheckerevent(object sender, q10eventargs e)
        {
            if (e.c != 0)
            {
                Console.WriteLine($"Result is: {e.c}");
            }
        }
        class library<T>
        {
            public T[] namelist = new T[5];
            
            public T name { get; set; }
            
            public T this[int index]
            {
                get { return namelist[index]; }
                set { namelist[index] = value; }
            }
            //public bool loaned { get; set; }
            
        }
        
        public static void q11()
        {
            library<int> intlst = new library<int>();
            library<string> NameLst = new library<string>();
            library<bool> boollst = new library<bool>();
            library<int> bookList = new library<int>();
            library<int> bookloanedto = new library<int>();
            NameLst.namelist =new string[] { "john", "mary", "peter", "parker", "wiliam" };
            intlst.namelist = new int[] { 111, 222, 333, 444, 555 };
            bookList.namelist = new int[] { 1001, 1002, 1003, 1004, 1005 };
            boollst.namelist = new bool[] { false, false, false, false, false };
            bookloanedto.namelist = new int[] { 0, 0, 0, 0, 0 };
            
            bool stay = true;
            
            while(stay)
            {
                Console.WriteLine("1. Lend a book");
                Console.WriteLine("2. Return a book");
                string input = Console.ReadLine();

                switch(input)
                {
                    case "1":
                        {
                            
                            Console.WriteLine("enter ID");
                            object id = Console.ReadLine();
                            int parsedid=0;
                            int parsedbookid = 0;
                            bool managetoborrow = false;
                            for(int i=0;i<bookList.namelist.Length;i++)
                            {
                                Console.WriteLine($"{i}: {bookList[i]}");
                            }
                            Console.Write("Enter option no of book you wish to borrow");
                            object bookid = Console.ReadLine();
                            try
                            {
                                 parsedid = int.Parse((string)id);
                                parsedbookid = int.Parse((string)bookid);
                            }
                            catch (ArgumentNullException e)
                            {
                                Console.WriteLine($"Argument null caught: " + e.Message);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine($"Format exception caught: {e.Message}");
                            }
                            catch (OverflowException e)
                            {
                                Console.WriteLine($"Over flow exception caught: {e.Message}");
                            }
                            catch(Exception e)
                            {
                                Console.WriteLine($"Exception caught: {e.Message}");
                            }
                            finally
                            {
                                
                                for (int i = 0; i < intlst.namelist.Length; i++)
                                {
                                    if (intlst[i] == parsedid)
                                    {
                                        if (boollst[i] == false)
                                        {
                                            boollst[i] = true;
                                            Console.WriteLine($"Name: {NameLst[i]} Student ID: {intlst[i]} has loaned book {bookList[parsedbookid]} ");
                                            bookloanedto[parsedbookid] = intlst[i];
                                            managetoborrow = true;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"{parsedid} have already borrowed a book");
                                        }
                                    }
                                    else
                                    {
                                        
                                    }
                                }
                                if(managetoborrow==false)
                                {
                                    Console.WriteLine("You do not have the privilege to lend this book as you do not belong to this class");
                                }
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("enter ID");
                            object id = Console.ReadLine();
                            int parsedid = 0;
                            //int parsedbookid = 0;
                            try
                            {
                                parsedid = int.Parse((string)id);

                            }
                            catch (ArgumentNullException e)
                            {
                                Console.WriteLine($"Argument null caught: " + e.Message);
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine($"Format exception caught: {e.Message}");
                            }
                            catch (OverflowException e)
                            {
                                Console.WriteLine($"Over flow exception caught: {e.Message}");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine($"Exception caught: {e.Message}");
                            }
                            finally
                            {
                                
                                for(int i=0;i<bookloanedto.namelist.Length;i++)
                                { 
                                    if(bookloanedto[i]==parsedid)
                                    {
                                        //boollst[bookloanedto[i]] = false;
                                        for(int k=0;k<intlst.namelist.Length;k++)
                                        {
                                            if (intlst[k] == parsedid && boollst[k] == true)
                                            {
                                                Console.WriteLine($"{NameLst[k]} has returned book id:{intlst[k]}");
                                                boollst[k] = false;
                                            }
                                        }
                                       
                                        bookloanedto[i] = 0;
                                        
                                        
                                    }
                                    
                                }
                            }
                                break;
                        }
                }
            }
           



            
        }
        class salary<T>
        {
            public T var1 { get; set; }
            public T totalpay { get; set; }
            public T totaltax { get; set; }
            public T totalinvestment { get; set; }
            public T takehomeafterbills { get; set; }
            public T insurancepaid { get; set; }
            public void print()
            {
                
               
            }
            
        }
        public static void q12print()
        {
            salary<double> a = new salary<double>();
            Console.WriteLine(a.var1);
            Console.WriteLine($"enter total probation months");
            int probmonths = int.Parse(Console.ReadLine());
            Console.WriteLine($"enter salary per month");
            double salarypermnth = double.Parse(Console.ReadLine());
            Console.WriteLine("Total months to calculate");
            int toalmths = int.Parse(Console.ReadLine());
            double probationpay = (probmonths * salarypermnth) * 0.8;
            a.var1 = probationpay;
            Console.WriteLine(a.var1);
        }
        public static void q12()
        {
            salary<double> a = new salary<double>();
           // salary<double> totalsalaryy = new salary<double>();
           // salary<double> calculatemonths = new salary<double>();
            Console.WriteLine($"enter total probation months");
            int probmonths = int.Parse(Console.ReadLine());
            Console.WriteLine($"enter salary per month");
            double salarypermnth = double.Parse(Console.ReadLine());
            Console.WriteLine("Total months to calculate");
            int toalmths = int.Parse(Console.ReadLine());
            double probationpay = (probmonths * salarypermnth)*0.8;
            double totalpay = (((toalmths - probmonths) * salarypermnth) + probationpay);
            double totaltax = (totalpay * 0.12);
            double investment = (totalpay * 0.15);
            double insurance = (totalpay * 0.5);
            double afterbills = totalpay - totaltax - investment - insurance;

            a.var1 = probationpay;
            a.totalpay = totalpay;
            a.takehomeafterbills = afterbills;
            a.totalinvestment = investment;
            a.totaltax = totaltax;
            a.insurancepaid = insurance;

            Thread probpay = new Thread(() => {  Console.WriteLine("Probation pay: " + a.var1); });
            Thread notaxtotalpay = new Thread(() => { Console.WriteLine("Total pay before bills & tax: " + a.totalpay); });
            Thread totaltaxpr = new Thread(() => { Console.WriteLine("Total tax paid: " + a.totaltax); });
            Thread totalinve = new Thread(() => { Console.WriteLine($"Total Investments: " + a.totalinvestment); });
            Thread totalinsu = new Thread(() => { Console.WriteLine("Total Insurance: " + a.insurancepaid); });
            Thread takehome = new Thread(() => { Console.WriteLine("Total take home pay after bills " + a.takehomeafterbills); });
            //Thread tp = new Thread(new ParameterizedThreadStart());
            //Console.WriteLine("Probation pay: "+a.var1);
            //Console.WriteLine("Total pay before bills & tax: "+a.totalpay);
            //Console.WriteLine("Total tax paid: "+a.totaltax);
            //Console.WriteLine($"Total Investments: "+a.totalinvestment);
            //Console.WriteLine("Total Insurance: "+a.insurancepaid);
            //Console.WriteLine("Total take home pay after bills "+a.takehomeafterbills);
            Thread.Sleep(5000);
            probpay.Start();
            
            notaxtotalpay.Start();
            totaltaxpr.Start();
            totalinve.Start();
            totalinsu.Start();
            takehome.Start();
            Console.WriteLine("All the pay went to:");
            //q12print();
            
            


        }

        class Question2
        {
            int Q2input;
            string[] Q2;

            public void getInput()
            {
                Console.Write("Enter the limit: ");
                Q2input = Convert.ToInt32(Console.ReadLine());
            }

            public void printnumbers()
            {
                Q2[0] = "0";
                for (int i = 1; i < Q2input + 1; i++)
                {
                    Thread.Sleep(1000);
                    for (int j = 1; j <= i; j++)
                    {
                        if (i == 1)
                        {
                            Console.Write(Q2[1]);
                        }
                        else
                        {
                            Console.Write(Q2[j] + "\t");
                        }
                    }
                    Console.WriteLine("\n");
                }
            }

            public void addNumbers()
            {
                Q2 = new string[Q2input + 1];
                for (int i = 1; i < Q2input + 1; i++)
                {
                    if (i == 1)
                    {
                        Thread.Sleep(500);
                        Q2[1] = "1";
                    }
                    else
                    {
                        Thread.Sleep(500);
                        Q2[i] = Convert.ToString(Convert.ToInt32(Q2[i - 1]) + Convert.ToInt32(Q2[i - 2]));
                    }
                }

            }
        }
        public static void q13()
        {
            //Q2
            Question2 Q2 = new Question2();
            Thread Q2add = new Thread(Q2.addNumbers);
            Q2.getInput();
            Q2add.Start();
            Thread.Sleep(100);
            Q2.printnumbers();
            Q2add.Abort();
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            //while (true)
            //{
            //q1();
            //q2();
            //3();
            //q4();
            // q6();
            //q8();
            //Q9();
            //q10();
            //q11();
            //q12();
            q13();
            //}
            Console.ReadLine();
        }

    }
}
/*
         Q1- Write a program which can take two integers to multiply and divide. Handle different Exceptions e.g. divide by zero exception, overflow exception etc.

Q2- Write a program which can create a directory and write a string to a file in the directory. Handle different exceptions. (Directory.Create to create directory, 
        File.Create to create file and File.WriteText to write string to file)

Q3- Create a stack to add integers to stack, implement Push and Pop. Handle the exceptions which can handle conditions if you pop more than available items from stack.

Q4- Create an array with 10 integers, Write an indexer to access its values and set values. Handle the exception if an unknown index is accessed and set.

Q5- Write a program to enter customer information to the customer collection. Customer information can contain id, name, address etc. Write methods and/or indexers 
        to access the customer information by id and name.if you access an customer information which is not present handle the exception and show appropriate messages.

Q7 Write a class which has a function which can take any function as an argument. Execute the function passed as an argument and Print the nameof the function to be executed.

Q8 Create a class which has an array with some values. Constitute a function which can eveluate whether a user provided parameter is present in the array using Predicate delegate.

Q9 Write a program which takes two arguments and does some operation. If the value of the two operand is same then throw a custom exception called MyArgumentException which passes a message "Two operands cannot be same". Print the message on the caller class.

Q10  Write a program which uses the EventHandler delagate to notify the caller using a custom eventArgs. In the custom eventargs you should have your Message and an exception object to notify whether exception occured or not. 

Q11  write a program to issue a book from library, to enter the library you need to be a student of the class (need to verify using some roll no etc.) but you can only issue one book at a time. give the details of student after the book is issued. *Use exception handling to show the error message  use generic class


Q12  Suppose you are working in an MNC.  after your joining there will be a probation period of 6 months, in this period you are drawing only 80% of your monthly salary. after that you will get the full salary.    Every month from your salary you have 
1. 12% tax
2. 8% to provident fund after paying the tax    
3. 5% to health insurance after paying PF              
4. 7% to Mutual Funds after paying Health insurance. 
* Now calculate the total amount of money you will get after all these investments in a year.
use exception handling to show the error msg. and create  generic class to store the data

        */
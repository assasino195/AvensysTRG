using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;


namespace ComplexClass
{
    class Program
    {
        class student
        {
            public string name { get; set; }
            public int id { get; set; }
            public student(string name,int id)
            {
                this.name = name;
                this.id = id;
            }
        }
        static void Main(string[] args)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            dict.Add(0, 10);
            dict.Add(1, 20);
            Console.WriteLine(dict.Count);

            

            foreach(var a in dict)
            {
                Console.WriteLine(a.Value);
                
            }
            int[] arr = new int[] { 2, 3, 5, 4, 1, 5, 2, 1, 2, 3, 4, 5, 1, 2, 3 };
            Dictionary<int, int> d = new Dictionary<int, int>();
            foreach(int i in arr)
            {
                if(d.ContainsKey(i))
                {
                    d[i]++;
                }
                else
                {
                    d.Add(i, 1);
                }
            }
            foreach(KeyValuePair<int,int> kvp in d)
            {
                Console.WriteLine($"key is {kvp.Key} value is: {kvp.Value}");
            }
            SortedDictionary<int, int> sortedD = new SortedDictionary<int, int>();
            foreach (KeyValuePair<int, int> kvp in d)
            {
                sortedD.Add(kvp.Key, kvp.Value);
            }
            Console.WriteLine();
            Console.WriteLine("sorted Dict");
            foreach (KeyValuePair<int, int> kvp in sortedD)
            {
                Console.WriteLine($"key is {kvp.Key} value is: {kvp.Value}");
            }
            bool stay = true;
            while (stay)
            {
                Console.WriteLine($"1. Complex Example\n2. Big Integer Examples\n3. Guide example" +
                    $"\n4.Tupple example\n5.Globalization\n6. List with var\n99. QUIT");
                string i = Console.ReadLine();
                switch (i)
                {
                    case "1":
                        {
                            complexExamples();
                            break;
                        }
                    case "2":
                        {
                            BigintegerExample();
                            break;
                        }
                    case "3":
                        {
                            guidexample();
                            break;
                        }
                    case "4":
                        {
                            TuppleExamples();
                            break;
                        }
                    case "5":
                        {
                            Globalization();
                            break;
                        }
                    case "6":
                        {
                            ListwithVar();
                            break;
                        }
                    case "7":
                        {
                            StackWithPeek();
                            break;
                        }
                    case "8":
                        {
                            QueueExample();
                            break;
                        }
                    case "9":
                        {
                            break;
                        }
                    case "99":
                        {
                            stay = false;
                            break;
                        }
                        //
                        //
                }
            }

            Console.ReadLine();
        }

        private static void QueueExample()
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(1);
            q.Enqueue(2);
            q.Enqueue(3);
            Console.WriteLine($"Size of queue: " + q.Count);
            Console.WriteLine($"Removing first element: {q.Dequeue()}");
            Console.WriteLine($"size of queue: " + q.Count);
            Console.WriteLine($"peeking element that will be removed :" + q.Peek());
            Console.WriteLine($"clearing queue");
            q.Clear();
            Console.WriteLine($"Size of queue: " + q.Count);
        }

        private static void StackWithPeek()
        {
            Stack<int> stk = new Stack<int>();
            stk.Push(1);
            stk.Push(2);
            stk.Push(3);
            Console.WriteLine($"Size of stack {stk.Count}");
            Console.WriteLine($"Last element is {stk.Peek()}");
            Console.WriteLine("Clearing stack");
            stk.Clear();
            Console.WriteLine($"Size of stack {stk.Count}");
        }

        private static void ListwithVar()
        {
            List<student> lst = new List<student>();
            lst.Add(new student("john", 1));
            lst.Add(new student("mary", 2));
            lst.Add(new student("doe", 3));
            foreach (var stu in lst)
            {
                Console.WriteLine(stu.id + stu.name);
            }
            lst.Reverse();

            foreach (var stu in lst)
            {
                Console.WriteLine(stu.id + stu.name);
            }
        }

        private static void Globalization()
        {
            var usen = new CultureInfo("en-US");
            var uken = new CultureInfo("en-GB");
            Console.WriteLine(usen.DisplayName);
            Console.WriteLine(uken.DisplayName);
            var french = new CultureInfo("fr-FR");
            Console.WriteLine(french.DisplayName);
            Console.WriteLine(usen.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek));
        }

        private static void TuppleExamples()
        {
            Tuple<int, double, string> tupple = new Tuple<int, double, string>(10, 1.2, "john");
            Console.WriteLine(tupple.Item1);
            var tupple2 = Tuple.Create(1, 1, "mary");
            var tupple3 = Tuple.Create(1, 2, 3, 4, 5, 6, 7, Tuple.Create(8, 9, 10, 11, 12));
            Console.WriteLine(tupple3.Item1);
            Console.WriteLine(tupple3.Item2);
            Console.WriteLine(tupple3.Item3);
            Console.WriteLine(tupple3.Item4);
            Console.WriteLine(tupple3.Item5);
            Console.WriteLine(tupple3.Item6);
            Console.WriteLine(tupple3.Item7);
            Console.WriteLine("item 1 value");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("item 2 value");
            Console.WriteLine($"{greaterthan(a,int.Parse(Console.ReadLine()))}");

            Console.WriteLine(tupple3.Rest.Item1.Item1);
            Console.WriteLine(tupple3.Rest.Item1.Item2);
            Console.WriteLine(tupple3.Rest.Item1.Item3);
            Console.WriteLine(tupple3.Rest.Item1.Item4);
            Console.WriteLine(tupple3.Rest.Item1.Item5);

            (int, string, string) valuetuple3 = (1, "sg", "john");
            (int id, string country, string name) person = (1, "sg", "john doe");
            Console.WriteLine(valuetuple3.Item1);
            Console.WriteLine(person.id);
            Console.WriteLine(person.country);
            Console.WriteLine(person.name);
            (int iid, string icountry, string iname) = getvaluetuple();//method to return tupple
            Console.WriteLine(iid);
            Console.WriteLine(icountry);
            Console.WriteLine(iname);
        }

        private static(int,string,string)getvaluetuple()
        {
            return (1, "sg", "john");
        }
        private static Tuple<int,bool>greaterthan(int a,int b)
        {
            if(a>b)
            {
                return Tuple.Create(a - b, true);
            }
            else
            {
                return Tuple.Create(a - b, false);
            }
        }
        private static void guidexample()
        {
            var guid1 = Guid.NewGuid();
            var guid2 = Guid.NewGuid();
            Console.WriteLine("equality check" + (guid1 == guid2));
            var bytes = new Byte[16];
            //var guid3 = Guid.NewGuid(bytes);
            //Console.WriteLine($"guide value of 3: {guid3}");
            for (var i = 0; i < 10; i++)
            {
                //var guidtemp = Guid.NewGuid(i);
                Console.WriteLine();
            }
        }

        private static void BigintegerExample()
        {
            BigInteger biginteger = new BigInteger(17583.4385);
            BigInteger biginteger2 = new BigInteger(200434.9392);
            Console.WriteLine("first big integer {0}", biginteger);
            Console.WriteLine("2nd big integer {0}", biginteger2);
            string str = "4343534324.342432";
            BigInteger biginteger3 = BigInteger.Parse(str);
            Console.WriteLine("String: {0}", str);
            Console.WriteLine("Value from stirng {0}", biginteger3);
            Console.WriteLine($"Power of 3, big integer{BigInteger.Pow(biginteger3, 3)}");
            Console.WriteLine($"Add in big integer {BigInteger.Add(biginteger, biginteger2)}");
        }

        private static void complexExamples()
        {
            Complex complex1 = new Complex(12, 6);
            Console.WriteLine($"First complex number is: {complex1}");
            Complex complex2 = new Complex(4, 8);
            Console.WriteLine($"2nd complex number is {complex2}");
            Console.WriteLine($"Sum of both complex number is: {complex1 + complex2}");
        }
    }
}

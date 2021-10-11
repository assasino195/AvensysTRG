using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QUestion_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>();
            string filepath = @"C:\Users\weiya\source\repos\AVENSYSTRG\AvensysTRG\week 6\week 5 exam\week 5 exam\q1\patinfo.txt";
            List<Patient> patlst = new List<Patient>();
            //if (File.ReadAllLines(filepath).ToList().Count > 0)
            //{
            List<string> lines = File.ReadAllLines(filepath).ToList();
            foreach (var line in lines)
            {
                string[] entires = line.Split(',');

                //try
                //{
                //    int a1 = int.Parse(entires[3]);
                //    int b1 = int.Parse(entires[4]);
                //    int c1 = int.Parse(entires[5]);
                    Patient temppat = new Patient(entires[0], entires[1], entires[2]);
                    patlst.Add(temppat);
                //}
                //catch (Exception e)
                //{
                //    Console.WriteLine("exception caught : " + e.Message);
                //}
            }
            //}
            //else
            //{

            //}
            bool stay = true;
            while (stay)
            {
                Console.WriteLine("Please Enter todays date");
                bool pass = DateTime.TryParse(Console.ReadLine(), out DateTime dtinput);
                if (pass)
                {
                    Console.WriteLine("please enter ur name");
                    string name = Console.ReadLine();
                    Console.WriteLine("please enter ur id");
                    string id = Console.ReadLine();
                    Console.WriteLine("1.register as new patient\n2.Emergency\n3.Clinical Operation\n4.Speclialist Recommendation/follow up\n5.Check flow\n0.Exit");
                    string opt = Console.ReadLine();
                    switch (opt)
                    {
                        case "1":
                            {
                                bool newpat = false;
                                foreach (var patient in patlst)
                                {
                                    if (patient.id.Equals(id))
                                    {
                                        Console.WriteLine("you have already registered before");
                                        break;
                                    }
                                    else
                                    {
                                        newpat = true;
                                    }
                                }
                                if (newpat)
                                {
                                    Patient p = new Patient(name, id,null);
                                    patlst.Add(p);
                                    Console.WriteLine("added new user to system");
                                }
                                break;
                            }

                        case "2":
                            {
                                foreach (var patient in patlst)
                                {
                                    if (patient.id.Equals(id))
                                    {
                                        patient.emergency(dtinput);


                                    }
                                }
                                break;
                            }

                        case "3":
                            {
                                foreach (var patient in patlst)
                                {
                                    if (patient.id.Equals(id))
                                    {
                                        patient.clinicalop(dtinput);
                                    }
                                }
                                break;
                            }

                        case "4":
                            {
                                foreach (var patient in patlst)
                                {
                                    if (patient.id.Equals(id))
                                    {
                                        patient.specialist(dtinput);
                                    }
                                }
                                break;
                            }
                        case "5":
                            {
                                int spec = 0;
                                int emg = 0;
                                int clic = 0;
                                //foreach (var pat in patlst)
                                //{
                                //    spec += pat.spec;
                                //    emg += pat.countemg;
                                //    clic += pat.clic;
                                //}
                                //Console.WriteLine($"Specialist Department has been visited a total of {spec}\nEmergency Department has been visted a total of {emg}\nClinical Department has been visited a total of {clic}");

                                foreach (var pat in patlst)
                                {
                                    string[] a = pat.issue.Split('.');
                                    //List<string> l = new List<string>();
                                    for (int i = 0; i < a.Length; i++)
                                    {
                                        string k = a[i];
                                        string[] l = k.Split(' ');
                                        if (DateTime.TryParse(l[0], out DateTime test) == true)
                                        {

                                            double diff = Math.Abs((dtinput - test).TotalDays);
                                            if (diff < 7)
                                            {
                                                if (l[l.Length-1].Equals("Emergency"))
                                                {
                                                    emg++;
                                                }
                                                else if (l[l.Length-1].Equals("clinical-Operations"))
                                                {
                                                    clic++;
                                                }
                                                else if (l[l.Length-1].Equals("Specialist"))
                                                {
                                                    spec++;
                                                }

                                            }
                                        }
                                        
                                    }
                                    Console.WriteLine("in the past 7 days");
                                    Console.WriteLine($"Specialist Department has been visited a total of {spec}\nEmergency Department has been visted a total of {emg}\nClinical Department has been visited a total of {clic}");
                                }
                                break;
                            }

                        case "0":
                            {
                                stay = false;
                                List<string> output = new List<string>();
                                foreach (var cus in patlst)
                                {
                                    output.Add($"{cus.name},{cus.id},{cus.issue}");
                                }
                                File.WriteAllLines(filepath, output);
                                Console.WriteLine("all entries updated");
                                break;
                            }
                    }

                }
                else
                {
                    Console.WriteLine("enter valid date");
                }
            }
            Console.ReadLine();
        }
    }
}

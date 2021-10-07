using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examsys
{
    class Program
    {
        static void Main(string[] args)
        {

            bool stay = true;

            //List<exam> pendinglst = new List<exam>();
            //List<exam> approvedlst = new List<exam>();
            List<exam> examlst = new List<exam>();
            List<student> studlst = new List<student>();
            List<question> queslst = new List<question>();
            student std1 = new student("john", "1");
            exam ex1 = new exam("C# exam", "100");
            studlst.Add(new student("Mary", "2"));
            examlst.Add(new exam("python exam", "101"));
            examlst.Add(ex1);
            studlst.Add(std1);
            while (stay)
            {
                Console.WriteLine("welcome to exam system");
            Console.WriteLine("Please enter your role");
            Console.WriteLine("1.Admin");
            Console.WriteLine("2.Student");
            string input1 = Console.ReadLine();
            
          
                switch (input1)
                {
                    case "1":
                        {
                            Console.WriteLine("1.add question to system");
                            Console.WriteLine("2.Check Approval list");
                            Console.WriteLine("3.display all question from system");
                            Console.WriteLine("4. add questions to exam");
                            string input2 = Console.ReadLine();
                            switch (input2)
                            {
                                case "1":
                                    {
                                        Console.WriteLine("enter the question you wish to add to the system");
                                        string questionn = Console.ReadLine();
                                        Console.WriteLine("Enter input for answer A");
                                        
                                        string answerA = Console.ReadLine();
                                        Console.WriteLine("Enter input for answer B");
                                        string answerB = Console.ReadLine();
                                        Console.WriteLine("Correct Answer is");
                                        string correcans = Console.ReadLine().ToUpper() ;
                                        question ques = new question(questionn,answerA,answerB,correcans);
                                        int temp = 1;
                                        foreach (exam e in examlst)
                                        {
                                            Console.WriteLine(temp+": "+e.examid + " " + e.examname);
                                            temp++;
                                        }
                                        Console.WriteLine("Enter exam ID you wish to add this question to");
                                        string inp = Console.ReadLine();
                                        int.TryParse(Console.ReadLine(), out int o);
                                        foreach(exam e in examlst)
                                        {
                                            if(e.examid.Equals(inp))
                                            {
                                                e.questionlist.Add(ques);
                                                Console.WriteLine("Question added into system");
                                            }
                                        }
                                        //queslst.Add(ques);
                                        

                                        break;
                                    }
                                case "2":
                                    {
                                        int count = 0;
                                        foreach (exam e in examlst)
                                        {
                                            
                                            foreach(student s in e.studentapplied)
                                            {
                                                Console.Write(count + ": ");
                                                Console.WriteLine(s.id+" "+s.name+"applied for: "+e.examname);
                                                count++;
                                            }
                                            //e.displaystudentapplied();
                                           
                                        }
                                        Console.WriteLine("Q. Exit");
                                        Console.WriteLine("Enter number you wish to approve of");
                                        string input3 = Console.ReadLine();
                                        int.TryParse(input3, out int k);
                                        if (input3.ToLower() == "q")
                                        {
                                            break;
                                        }
                                        else if (count >= k - 1)
                                        {
                                            int tcount = 0;
                                            foreach (exam e in examlst)
                                            {
                                                foreach (student s in e.studentapplied)
                                                {
                                                    if (tcount == k)
                                                    {
                                                        e.examlst.Add(s);
                                                        e.Approvestudent();
                                                        e.studentapplied.Remove(s);
                                                        tcount++;
                                                        break;
                                                    }
                                                    else { tcount++; }
                                                    
                                                }
                                               
                                            }

                                        }
                                        break;
                                    }
                                case "3":
                                    {
                                        
                                        foreach(question q in queslst)
                                        {
                                            Console.WriteLine(q.actualquestion);
                                        }
                                        Console.WriteLine("Enter number you wish to add to exam");
                                        int.TryParse(Console.ReadLine(), out int o);
                                      

                                        break;
                                    }
                                case "4":
                                    {
                                       
                                        break;
                                    }
                            }
                            break;
                        }
                    case "2":
                        {
                            Console.WriteLine("Enter student ID");
                            string input6 = Console.ReadLine();
                            foreach (student s in studlst)
                            {
                                if (s.id.Equals(input6))
                                {
                                    Console.WriteLine($"1.Apply for Exams\n2.Show Approval status\n3.Take exam");
                                    string input4 = Console.ReadLine();
                                    switch (input4)
                                    {
                                        case "1":
                                            {
                                                int tempcount = 0;
                                                foreach(exam e in examlst)
                                                {
                                                    Console.WriteLine($"{tempcount + 1}.{e.examname} {e.examid}");
                                                    tempcount++;
                                                }
                                              
                                                Console.WriteLine("Enter number you wish to apply for");
                                                int.TryParse(Console.ReadLine(), out int p);
                                                if (p - 1 > tempcount)
                                                {
                                                    Console.WriteLine("Enter a valid option");
                                                }
                                                else
                                                {
                                                    if (examlst[p - 1].examlst.Contains(s))
                                                    {
                                                        Console.WriteLine("you are already enrolled for this exam");
                                                    }
                                                    else if (examlst[p - 1].studentapplied.Contains(s))
                                                    {
                                                        Console.WriteLine("you already applied for this exam");
                                                    }
                                                    else
                                                    {
                                                        examlst[p - 1].addstudentopending(s);
                                                        Console.WriteLine("Applied for exam");
                                                    }
                                                }
                                                break;
                                            }
                                        case "2":
                                            {
                                                foreach (exam exp in examlst)
                                                {
                                                    if (exp.studentapplied.Contains(s))
                                                    {
                                                        Console.WriteLine("you have applied for:"+exp.examid+" "+exp.examname);
                                                    }
                                                    else if(exp.examlst.Contains(s))
                                                    {
                                                        Console.WriteLine("you can take this exam: " + exp.examid + " " + exp.examname);
                                                    }
                                                }
                                                break;
                                            }
                                        case "3":
                                            {
                                                foreach(exam e in examlst)
                                                {
                                                    e.displaystudentinexamlst(s);
                                                }
                                                Console.WriteLine("Enter exam ID you wish to take");
                                                string input7 = Console.ReadLine();
                                                foreach(exam e in examlst)
                                                {
                                                    if(e.examlst.Contains(s))
                                                    {
                                                       if(e.examid==input7)
                                                        {
                                                            e.takeexam();
                                                            Console.WriteLine($"Final score is: {e.score}/{e.questionlist.Count}");
                                                        }

                                                    }
                                                }
                                                break;
                                            }
                                        case "4":
                                            {
                                                
                                                foreach(exam e in examlst)
                                                {
                                                    if (e.examlst.Contains(s))
                                                    {
                                                        if (e.attempted)
                                                        {
                                                            Console.WriteLine(e.examid + " " + e.examname + "Score: " + e.score);
                                                        }
                                                    }
                                                }
                                                break;
                                            }

                                    }

                                }
                            }
                            break;

                        }

                }
            }
        }
    }
}
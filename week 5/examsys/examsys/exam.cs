using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examsys
{
    class exam
    {
        public string examname { get; set; }
        public string examid { get; set; }
        public bool attempted = false;
        public int score { get; set; }
        public List<student> examlst = new List<student>();
        public List<student> studentapplied = new List<student>();
        public List<question> questionlist = new List<question>();
        public void Approvestudent()
        {
            //examlst.Add();
        }
        public void addstudentopending(student s)
        {
            studentapplied.Add(s);
        }
        public void displaystudentapplied()
        {
            foreach(student s in studentapplied)
            {
                Console.WriteLine(s.id+" "+s.name);
            }
        }
        public void displaystudentinexamlst(student s)
        {
            if(examlst.Contains(s))
            {
                Console.WriteLine(examname+" "+examid);
            }
        }
        public exam(string examname, string examid)
        {
            this.examname = examname;
            this.examid = examid;
          // approved = i;
            
        }
        public void takeexam()
        {
            foreach(question q in questionlist)
            {
                Console.WriteLine(q.actualquestion);
                Console.WriteLine("A: "+q.A);
                Console.WriteLine("B: "+q.B);
                string userans = Console.ReadLine().ToUpper();
                if(userans.Equals(q.correc))
                {
                    score++;
                    Console.WriteLine("CORRECT!");
                }
                else
                {
                    Console.WriteLine("WRONG!");
                }

                attempted = true;
            }
        }
        
        
    }
}

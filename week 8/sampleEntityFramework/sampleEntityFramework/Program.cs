using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleEntityFramework
{
    //[Table("FormerStudent")]
    //public class Formerstudent:Student
    //{
    //    public School school { get; set; }
    //    public int PassYear { get; set; }
    //}
    //[Table("CurrentStudent")]
    //public class CurrentStudent:Student
    //{
    //    public School school { get; set; }
    //    public int CurrentGrade { get; set; }
    //}
    [Table("MyTable")]
    public class Student
    {
        //[Column("StudentName",Order =2,TypeName ="text")]
        //[MinLength(5)]
        public string studName { get; set; }
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
       //[Column("StudID",Order =0)]
        public int studentID { get; set; }
        
        //[Column("Address",Order =1)]
        //[Required]
        public string studentAdd { get; set; }
        //[Column("StudentRollNo",Order =3)]
        //[Key]
        public int studentrollno { get; set; }
        //[NotMapped]
        public string remarks { get; set; }
        public School School { get; set; }
    }
    public class School
    {
        public string Name { get; set; }
        public int SchoolID { get; set; }
        public List<Student> StudentList { get; set; }
        public Student student { get; set; }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi welcome");
            using (StudentManagementContext stucontext = new StudentManagementContext())
            {
                Student student1 = new Student() { studentID=1,studName = "Johnyy",remarks="hi",studentAdd="Singapore road",studentrollno=100 };
                School school1 = new School() { Name = "FirstWorld" };
               // student1.School = school1;
                //Formerstudent student2 = new Formerstudent() { studentID=2,Name = "Tim" };
                //student2.school = school1;
                //CurrentStudent student3 = new CurrentStudent() {studentID=3, Name = "Jason" };
               // student3.school = school1;
               //stucontext.Schools.Add(school1);
                stucontext.Students.Add(student1);
               // stucontext.Students.Add(student2);
               // stucontext.Students.Add(student3);
                
                
                stucontext.SaveChanges();
            }
            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}

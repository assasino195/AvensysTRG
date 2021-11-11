using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sampleEntityFramework
{
    public class StudentManagementContext:DbContext
    {
        public StudentManagementContext():base()//"Name=SchoolManagementSystem")//pass in name to base() to create db with specificed name
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<StudentManagementContext>());
            
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<StudentManagementContext>());
           Database.SetInitializer(new DropCreateDatabaseAlways<StudentManagementContext>());
           
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

         base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("My");
            modelBuilder.Entity<Student>().ToTable("MyTable", "MytableSchema");
            modelBuilder.Entity<Student>().HasOptional(s => s.School).WithRequired(t => t.student);
        //    modelBuilder.Entity<Formerstudent>().Map(m =>
        //    {
        //        m.MapInheritedProperties();
        //        m.ToTable("FormerStudent");
        //    });
        //    modelBuilder.Entity<CurrentStudent>().Map(m =>
        //    {
        //        m.MapInheritedProperties();
        //        m.ToTable("CurrentStudent");
        //    });
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }

    }
}

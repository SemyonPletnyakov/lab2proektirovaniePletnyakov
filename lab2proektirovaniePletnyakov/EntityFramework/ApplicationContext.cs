using lab2proektirovaniePletnyakov.EntityFramework.Tables;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2proektirovaniePletnyakov.EntityFramework
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public ApplicationContext()
        {
            if (Database.EnsureCreated())
            {
                Students.Add(new Student { Name = "Алексей" });
                Students.Add(new Student { Name = "Дмитрий" });
                Subjects.Add(new Subject { Name = "Математика" });
                Subjects.Add(new Subject { Name = "История" });
                SaveChanges();
            }

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=lab2Pletnyakov;Trusted_Connection=True;");
        }
    }
}

using Microsoft.EntityFrameworkCore;
using StudentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentApp.Context
{
    internal class StudentDbContext : DbContext
    {
        public StudentDbContext()
        {
            
        }

        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=ANAMIKA\SQLSERVER;Database=Test100;Trusted_Connection=True;TrustServerCertificate=true");
        }
    }
}

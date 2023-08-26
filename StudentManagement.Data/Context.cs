using Microsoft.EntityFrameworkCore;
using StudentManagement.Model.Student;
using StudentManagement.Model.Subjects;
using StudentManagement.Model.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace StudentManagement.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Subjects> Subjects { get; set; }
        public DbSet<ExternalUser> ApplicationUsers { get; set; }
    }
}

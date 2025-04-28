using API_StudentCrud.Model;
using System;
using Microsoft.EntityFrameworkCore;

namespace API_StudentCrud.Data
{
    public class StudentDBContext :DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options) : base(options)
        {

        }
        public DbSet<Student> Student_Master { get; set; }
    }
    
}

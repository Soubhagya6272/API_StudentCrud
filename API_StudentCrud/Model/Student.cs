using System.ComponentModel.DataAnnotations;

namespace API_StudentCrud.Model
{
    public class Student
    {
        [Key]
        public int Sid { get; set; }
        public string? Sname { get; set; }    
        public int age { get; set; }
        public string? Phone { get; set; }
        public int Rollno { get; set; }

    }
}

using System;
using API_StudentCrud.Data;
using API_StudentCrud.Interface;
using API_StudentCrud.Model;

namespace API_StudentCrud.Concrete
{
    public class StudentRepository :IRepository
    {
        StudentDBContext con;

        public StudentRepository(StudentDBContext obj)
        {
            this.con = obj;
        }

        public int SaveStudent(Student student)
        {
            Student st = new Student();
            st.Sname = student.Sname;
            st.age = student.age;
            st.Phone = student.Phone;
            st.Rollno = student.Rollno;

            con.Student_Master.Add(st);
            con.SaveChanges();
            return 1;
        }

        public int UpdateStudent(Student student)
        {
            Student st = new Student();
            st.Sname = student.Sname;
            st.age = student.age;
            st.Phone = student.Phone;
            st.Rollno = student.Rollno;

            con.Student_Master.Update(st);
            con.SaveChanges();
            return 1;
        }
    }
}

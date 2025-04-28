using System;
using API_StudentCrud.Data;
using API_StudentCrud.Interface;
using API_StudentCrud.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static API_StudentCrud.Model.ApiResponseModel;

namespace API_StudentCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        StudentDBContext con;
        IRepository repository;
        private readonly IRepository repositoryInterface;

        public StudentController(StudentDBContext _con, IRepository _repository, IRepository repositoryInterface)
        {
            this.con = _con;
            this.repository = _repository;
            this.repositoryInterface = repositoryInterface;
        }

        [HttpPost]
        [Route("InsertStudent")]
        public async Task<IActionResult> InsertStudent(Student student)
        {
            ApiGetResponseModel<string> response = new ApiGetResponseModel<string>();

            int count = repositoryInterface.SaveStudent(student);
            if (count == 1)
            {
                response.IsSuccess = true;
                response.Message = "Student Inserted Sucessfully";
                response.Result = null;
                response.ExtraData = "";
                response.TotalRecord = 0;
                return Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something Went Wrong";
                response.Result = null;
                response.ExtraData = "";
                response.TotalRecord = 0;
                return Ok(response);

            }
        }

        [HttpGet]
        [Route("StudentList")]
        public async Task<IActionResult> StudentList()
        {
            var students = await con.Student_Master.ToListAsync();
            return Ok(students);
        }

        [HttpPut]
        [Route("UpdateStudent/{id}")]
        public async Task<IActionResult> UpdateStudent(int id, [FromBody] Student student)
        {
            //var existingStudent = await con.Student_Master.FindAsync(id);
            //if (existingStudent == null)
            //{
            //    return NotFound(new { message = "Student not found" });
            //}

            //existingStudent.Sname = student.Sname;
            //existingStudent.age = student.age;
            //existingStudent.Phone = student.Phone;
            //existingStudent.Rollno = student.Rollno;

            //con.Student_Master.Update(existingStudent);
            //await con.SaveChangesAsync();

            //return Ok(new { message = "Student updated successfully" });

            ApiGetResponseModel<string> response = new ApiGetResponseModel<string>();

            int count = repositoryInterface.UpdateStudent(student);
            if (count == 1)
            {
                response.IsSuccess = true;
                response.Message = "Student Updated Sucessfully";
                response.Result = null;
                response.ExtraData = "";
                response.TotalRecord = 0;
                return Ok(response);
            }
            else
            {
                response.IsSuccess = false;
                response.Message = "Something Went Wrong";
                response.Result = null;
                response.ExtraData = "";
                response.TotalRecord = 0;
                return Ok(response);

            }

        }
        [HttpDelete]
        [Route("DeleteStudent/{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var student = await con.Student_Master.FindAsync(id);
            if (student == null)
            {
                return NotFound(new { message = "Student not found" });
            }

            con.Student_Master.Remove(student);
            await con.SaveChangesAsync();

            return Ok(new { message = "Student deleted successfully" });
        }
    }
}

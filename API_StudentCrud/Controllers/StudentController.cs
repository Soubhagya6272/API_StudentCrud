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
    }
}

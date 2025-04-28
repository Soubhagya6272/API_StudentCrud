using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StudentWebApp.Models;

namespace StudentWebApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;

        public StudentController(HttpClient client)
        {
            _client = client;
            _apiBaseUrl = "https://localhost:44357/api/Student";  
        }

        [HttpGet]
        public IActionResult InsertStudent()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InsertStudent(Student student)
        {
            var jsonData = JsonConvert.SerializeObject(student);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"{_apiBaseUrl}/InsertStudent", content);

            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Student inserted successfully!";
                return RedirectToAction("InsertStudent");
            }
            else
            {
                TempData["Error"] = "Something went wrong while inserting.";
                return View(student);
            }
        }

        [HttpGet]
        public async Task<IActionResult> StudentList()
        {
            List<Student> students = new List<Student>();

            var response = await _client.GetAsync($"{_apiBaseUrl}/StudentList");

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                students = JsonConvert.DeserializeObject<List<Student>>(result);
            }

            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _client.GetAsync($"{_apiBaseUrl}/StudentList");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var students = JsonConvert.DeserializeObject<List<Student>>(data);
                var student = students.FirstOrDefault(s => s.Sid == id);

                if (student != null)
                    return View(student);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {

            var jsonData = JsonConvert.SerializeObject(student);
            var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{_apiBaseUrl}/UpdateStudent/{student.Sid}", content);


            if (response.IsSuccessStatusCode)
            {
                TempData["Success"] = "Student Updated successfully!";
                return RedirectToAction("StudentList");
            }
            else
            {
                TempData["Error"] = "Something went wrong while inserting.";
                return View(student);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            HttpResponseMessage response = await _client.DeleteAsync($"api/Student/DeleteStudent/{id}");

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("StudentList");
            }
            return NotFound();
        }
    }
}

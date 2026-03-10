using Microsoft.AspNetCore.Mvc;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/student")]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>()
        {
            new Student { Id = "1", Name = "Ram", Age = 20, Course = "BIT" },
            new Student { Id = "2", Name = "Shyam", Age = 21, Course = "BBA" }
        };

        // A) GET api/student/getall
        [HttpGet("getall")]
        public IActionResult GetAllStudents()
        {
            return Ok(students);
        }

        // B) GET api/student/{id}
        [HttpGet("{id}")]
        public IActionResult GetStudentById(string id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // C) POST api/student/add
        [HttpPost("add")]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (student == null)
                return BadRequest("Invalid student data");

            students.Add(student);
            return Ok("Student added successfully");
        }

        // D) PUT api/student/update
        [HttpPut("update")]
        public IActionResult UpdateStudent([FromBody] Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == updatedStudent.Id);

            if (student == null)
                return NotFound("Student not found");

            student.Name = updatedStudent.Name;
            student.Age = updatedStudent.Age;
            student.Course = updatedStudent.Course;

            return Ok("Student updated successfully");
        }

        // E) DELETE api/student/delete/{id}
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(string id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);

            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);

            return Ok("Student deleted successfully");
        }
    }
}
using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;
using HariomToppersAcademy.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HariomToppersAcademy.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository studentRepo;

        public StudentController(IStudentRepository studentRepo)
        {
            this.studentRepo = studentRepo;
        }
        
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            return studentRepo.GetAllStudents();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            return studentRepo.GetStudent(id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public string Post([FromBody] StudentDto studentDto)
        {
            return studentRepo.AddStudent(studentDto);
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] StudentDto studentDto)
        {
            return studentRepo.UpdateStudent(id,studentDto);
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return studentRepo.DeleteStudent(id);
        }

        // Register for course
        // Post/<StudentController>/5
        [HttpPost("register/{studId}/{courseId}")]
        public string RegisterCourse(int studId,int courseId)
        {
            return studentRepo.RegisterCourse(studId,courseId);
        }
        
        // UnRegister course
        // Post/<StudentController>/5
        [HttpPost("withdraw/{studId}/{courseId}")]
        public string UnRegisterCourse(int studId,int courseId)
        {
            return studentRepo.UnRegisterCourse(studId,courseId);
        }
    }
}

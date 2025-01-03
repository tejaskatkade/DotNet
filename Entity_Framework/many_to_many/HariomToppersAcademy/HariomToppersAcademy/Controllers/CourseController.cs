using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;
using HariomToppersAcademy.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HariomToppersAcademy.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseNameRepository repository;

        public CourseController(ICourseNameRepository repository)
        {
                this.repository = repository;
        }
        // GET: api/<CourseController>
        [HttpGet]
        public List<CourseName> Get()
        {
            return repository.GetAllCourseNames();
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public CourseName Get(int id)
        {
            return repository.GetCourseName(id);
        }

        // POST api/<CourseController>
        [HttpPost]
        public string Post([FromBody] CourseDto courseDto)
        {
            return repository.AddCourse(courseDto);
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] CourseDto courseDto)
        {
            return repository.UpdateCourse(id, courseDto);
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return repository.DeleteCourse(id);
        }
    }
}

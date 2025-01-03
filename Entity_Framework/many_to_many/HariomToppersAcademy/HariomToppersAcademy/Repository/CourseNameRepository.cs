using HariomToppersAcademy.Context;
using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace HariomToppersAcademy.Repository
{
    public class CourseNameRepository : ICourseNameRepository
    {
        private readonly ApplicationContext context;

        public CourseNameRepository(ApplicationContext context)
        {
            this.context = context;
        }
        public string AddCourse(CourseDto courseDto)
        {
            string msg = "Course not Added";
            CourseName courseName = new CourseName();
            courseName.Name = courseDto.Name;
            courseName.Fees = courseDto.Fees;
            courseName.CreatedOn = DateTime.Now;
            courseName.UpdatedOn = DateTime.Now;
            courseName.Students = new List<Student>();

            context.Add(courseName);
            if (context.SaveChanges() > 0)
            {
                return "Course Added";
            }
            return msg;
        }

        public string DeleteCourse(int id)
        {
            string msg = "Course not delete";
            CourseName courseName = context.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            if (courseName != null)
            {

                courseName.Students.ForEach(student => student.courseNames.Remove(courseName));
                context.Courses.Remove(courseName);

                if (context.SaveChanges() > 0)
                {
                    msg = "Course Deleted";
                }
            }
            else
            {
                msg = "Course Not Found";
            }
            return msg;

        }

        public List<CourseName> GetAllCourseNames()
        {
            return context.Courses.Include(c => c.Students).ToList();
        }

        public CourseName GetCourseName(int id)
        {
            return context.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == id);
        }

        public string UpdateCourse(int id,CourseDto courseDto)
        {
            string msg = "Course not Updated";
            CourseName courseName = context.Courses.Include(c => c.Students).FirstOrDefault(c => c.Id == id);
            if (courseName != null)
            {

                courseName.Name = courseDto.Name;
                courseName.Fees = courseDto.Fees;
                courseName.UpdatedOn = DateTime.Now;

                if (context.SaveChanges() > 0)
                {
                    return "Course Updated";
                }
            }
            else
            {
                msg = "Course Not found";
            }
            return msg;
        }
    }
}

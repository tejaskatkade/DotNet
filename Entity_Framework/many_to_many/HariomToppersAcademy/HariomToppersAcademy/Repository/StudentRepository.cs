using HariomToppersAcademy.Context;
using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;
using Microsoft.EntityFrameworkCore;

namespace HariomToppersAcademy.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationContext context;

        public StudentRepository(ApplicationContext context)
        {
                this.context = context;
        }

        public string RegisterCourse(int StudentId, int CourseId)
        {
            string msg = "Registration Failed";
            Student student = context.Students.FirstOrDefault(s => s.Id == StudentId);
            if (student == null)
            {
                return "Student Not Found";
            }

            CourseName courseName = context.Courses.FirstOrDefault(c => c.Id == CourseId);
            if (courseName == null)
            {
                return "Course Not Found";
            }

            student.courseNames.Add(courseName);
            try
            {
                if (context.SaveChanges() > 0)
                {
                    return "Student Added to Course : " + courseName.Name;
                }
            }
            catch (Exception ex) {
                return ex.ToString();
            }
            return msg;
        }


        public string AddStudent(StudentDto studentDto)
        {
            string msg = "Student not Added";
            Student student = new Student();
            student.Name = studentDto.Name;
            student.Age = studentDto.Age;
            student.UpdatedOn = DateTime.Now;
            student.CreatedOn = DateTime.Now;
            student.courseNames = new List<CourseName>();
         
            context.Add(student);
            if(context.SaveChanges() > 0)
            {
                return "Student Added";
            }
            return msg;
        }

        public string DeleteStudent(int id)
        {
            string msg = "Student not delated";
            Student student = context.Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {

                student.courseNames.ForEach(course => {
                        course.Students.Remove(student);
                       // student.courseNames.Remove(course);
                    });
                
                context.Students.Remove(student);

                if (context.SaveChanges() > 0)
                {
                    msg = "Student Deleted";
                }
            }
            else
            {
                msg = "Student Not Found";
            }
            return msg;


        }



        public List<Student> GetAllStudents()
        {
            return context.Students.Include(s => s.courseNames).ToList();
        }

        public Student GetStudent(int id)
        {
            return context.Students.Include(s => s.courseNames).FirstOrDefault(s => s.Id == id);
        }

        public string UpdateStudent(int id, StudentDto studentDto)
        {
            string msg = "Student not Updated";
            Student student = context.Students.FirstOrDefault(s => s.Id == id);
            if(student != null)
            {
                student.Name = studentDto.Name;
                student.Age = studentDto.Age;
                student.UpdatedOn = DateTime.Now;

                if (context.SaveChanges() > 0)
                {
                    msg = "Student Updated";
                }
            }
            else
            {
                msg ="Student Not Found";
            }
            return msg;
        }

        public string UnRegisterCourse(int StudentId, int CourseId)
        {
            string msg = "Failed";
            Student student = context.Students.Include(c=>c.courseNames).FirstOrDefault(s => s.Id == StudentId);
            if (student == null)
            {
                return "Student Not Found";
            }

            CourseName courseName = context.Courses.Include(s => s.Students).FirstOrDefault(c => c.Id == CourseId);
            if (courseName == null)
            {
                return "Course Not Found";
            }
            bool res = student.courseNames.Remove(courseName);
           /* Console.WriteLine(res);
            if (!res)
            {
                return msg;
            }*/
            if (context.SaveChanges() > 0)
            {
                return student.Name +" Withdraw Course : " + courseName.Name;
            }
            return msg;
        }
    }
}

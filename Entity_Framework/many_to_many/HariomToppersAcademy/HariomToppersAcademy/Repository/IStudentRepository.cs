using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;

namespace HariomToppersAcademy.Repository
{
    public interface IStudentRepository
    {

        string RegisterCourse(int StudentId, int CourseId);
        String AddStudent(StudentDto studentDto);
        string UpdateStudent(int id, StudentDto studentDto);
        Student GetStudent(int id);
        List<Student> GetAllStudents();
        string DeleteStudent(int id);
        string UnRegisterCourse(int studId, int courseId);
    }
}


using HariomToppersAcademy.DTO;
using HariomToppersAcademy.Entity;

namespace HariomToppersAcademy.Repository
{
    public interface ICourseNameRepository
    {
        string AddCourse(CourseDto courseDto);
        string DeleteCourse(int id);
        CourseName GetCourseName(int id);
        List<CourseName> GetAllCourseNames();
        string UpdateCourse(int id, CourseDto courseDto);


    }
}

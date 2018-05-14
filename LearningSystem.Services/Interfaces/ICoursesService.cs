using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Interfaces.Services
{
    public interface ICoursesService
    {
        DetailsCourseVM GetDetails(int id);
    }
}
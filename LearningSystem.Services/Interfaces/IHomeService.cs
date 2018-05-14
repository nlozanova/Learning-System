using System.Collections.Generic;
using LearningSystem.Models.ViewModels.Courses;

namespace LearningSystem.Interfaces.Services
{
    public interface IHomeService
    {
        IEnumerable<CourseVM> GetAllCources();
    }
}
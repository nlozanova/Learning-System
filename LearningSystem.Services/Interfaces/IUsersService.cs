using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;

namespace LearningSystem.Interfaces.Services

{
    public interface IUsersService
    {
        void EditUser(EditUserVM model, string userName);
        void EnrollStudentInCourse(int courseId, Student student);
        Student GetCurrentStudent(string userName);
        EditUserVM GetEditVM(string userName);
        ProfileVM GetProfileVM(string userName);
    }
}
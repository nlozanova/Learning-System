using LearningSystem.Models.EntityModels;

namespace LearningSystem.Interfaces.Services
{
    public interface IAccountService
    {
        void CreateStudent(ApplicationUser user);
    }
}
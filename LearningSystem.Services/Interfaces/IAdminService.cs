using LearningSystem.Models.ViewModels.Admin;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LearningSystem.Interfaces.Services
{
    public interface IAdminService
    {
        AdminPageVM GetAdminPage();
        AdminAddEditCourseVM GetEditCourse(int id);
        void EditCourse(AdminAddEditCourseVM bind);
        void AddCourse(AdminAddEditCourseVM bind);
        AdminEditUserVM GetEditUserVM(int id);
        void EditUser(AdminEditUserVM bind);
        List<SelectListItem> GetCourseTrainers();
    }
}
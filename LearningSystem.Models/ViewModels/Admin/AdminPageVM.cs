using LearningSystem.Models.ViewModels.Courses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.ViewModels.Admin
{
    public class AdminPageVM
    {
        public IEnumerable<CourseVM> Courses { get; set; }
        public IEnumerable<AdminPageUserVM> Users { get; set; }
    }
}

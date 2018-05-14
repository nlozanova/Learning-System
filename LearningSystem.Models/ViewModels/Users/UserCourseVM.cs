using LearningSystem.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.ViewModels.Users
{
    public class UserCourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Grade Grade { get; set; }

    }
}

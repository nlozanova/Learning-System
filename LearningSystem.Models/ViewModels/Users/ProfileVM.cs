using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.ViewModels.Users
{
    public class ProfileVM
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Username { get; set; }

        public IEnumerable<UserCourseVM> EnrolledCourses { get; set; }
    }
}

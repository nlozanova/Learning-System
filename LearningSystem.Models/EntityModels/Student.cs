using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.EntityModels
{
    public class Student
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();

        }
        public int Id { get; set; }

        public virtual ApplicationUser User { get; set; }
        
        public ICollection<Course> Courses { get; set; }
        
    }
}

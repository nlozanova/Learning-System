using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.ViewModels.Courses
{
    public class DetailsCourseVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }

        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.EntityModels;
using AutoMapper;
using LearningSystem.Interfaces.Services;

namespace LearningSystem.Services
{
    public class HomeService : Service, IHomeService
    {
        public IEnumerable<CourseVM> GetAllCources()
        {
            IEnumerable<Course> courses = this.Context.Courses.ToArray();
            IEnumerable<CourseVM> vms = Mapper.Map<IEnumerable<Course>, IEnumerable <CourseVM>>(courses);
            return vms;
        }
    }
}

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
    public class CoursesService : Service, ICoursesService
    {
        public DetailsCourseVM GetDetails(int id)
        {
            Course course = this.Context.Courses.Find(id);
            if ( course == null)
            {
                return null;

            }

            DetailsCourseVM vm = Mapper.Map<Course, DetailsCourseVM>(course);
            return vm;
        }
    }
}

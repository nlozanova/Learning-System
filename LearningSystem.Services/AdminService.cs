using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Courses;
using AutoMapper;
using LearningSystem.Interfaces.Services;
using System.Web.Mvc;

namespace LearningSystem.Services
{
    public class AdminService : Service, IAdminService
    {
        public AdminPageVM GetAdminPage()
        {
            AdminPageVM page = new AdminPageVM();
            IEnumerable<Course> courses = this.Context.Courses;
            IEnumerable<Student> students = this.Context.Students;

            IEnumerable<CourseVM> courseVMs = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseVM>>(courses);
            IEnumerable<AdminPageUserVM> userVMs = Mapper.Map<IEnumerable<Student>, IEnumerable<AdminPageUserVM>>(students);
            page.Users = userVMs;
            page.Courses = courseVMs;

            return page;
        }

        public AdminAddEditCourseVM GetEditCourse(int id)
        {
            Course course = this.Context.Courses.Find(id);
            AdminAddEditCourseVM vm = Mapper.Map<Course, AdminAddEditCourseVM>(course);
            return vm;
        }

        public void EditCourse(AdminAddEditCourseVM model)
        {
            Course course = this.Context.Courses.Find(model.Id);

            course.Name = model.Name;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.Description = model.Description;
            course.Trainer = this.Context.Users.Find(model.TrainerId);

            this.Context.SaveChanges();

        }
        public void AddCourse(AdminAddEditCourseVM model)
        {
            Course course = new Course();

            course.Name = model.Name;
            course.StartDate = model.StartDate;
            course.EndDate = model.EndDate;
            course.Description = model.Description;
            course.Trainer = this.Context.Users.Find(model.TrainerId);

            this.Context.Courses.Add(course);
            this.Context.SaveChanges();
        }

        public AdminEditUserVM GetEditUserVM(int id)
        {
            Student student = this.Context.Students.Find(id);

            //AdminEditUserVM vm = Mapper.Map<Student, AdminEditUserVM>(student);
            AdminEditUserVM vm = new AdminEditUserVM();

            vm.Id = student.Id;
            vm.Name = student.User.Name;
            vm.Email = student.User.Email;
            vm.BirthDate = student.User.Birthdate;
            return vm;
        }

        public void EditUser(AdminEditUserVM model)
        {
            Student student = this.Context.Students.Find(model.Id);

            student.User.Name = model.Name;
            student.User.Birthdate = model.BirthDate;
            student.User.Email = model.Email;

            this.Context.SaveChanges();

        }

        public List<SelectListItem> GetCourseTrainers()
        {
            var data = this.Context.Users.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.Name }).ToArray();
            List<SelectListItem> trainersList = new List<SelectListItem>();

            for (int i = 0; i < data.Length; i++)
            {
                trainersList.Add(data[i]);
            }
            return trainersList;         
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;
using AutoMapper;
using Microsoft.AspNet.Identity;
using LearningSystem.Interfaces.Services;

namespace LearningSystem.Services
{
    public class UsersService : Service, IUsersService
    {
        public Student GetCurrentStudent(string userName)
        {
            var user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            Student student = this.Context.Students.FirstOrDefault(student1 => student1.User.Id == user.Id);

            return student;
        }

        public void EnrollStudentInCourse(int courseId, Student student)
        {
            Course wantedCourse = this.Context.Courses.Find(courseId);

            //student.Courses.Add(wantedCourse);
            wantedCourse.Students.Add(student);
            this.Context.SaveChanges();

        }

        public ProfileVM GetProfileVM(string userName)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == userName);
            ProfileVM vm = Mapper.Map<ApplicationUser, ProfileVM>(currentUser);
            Student currentStudent = this.Context.Students.FirstOrDefault(student => student.User.Id == currentUser.Id);


            //doesnt work!
            //vm.EnrolledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseVM>>(currentStudent.Courses);

            //
            //test second way filling the enrolled courses
            var students = this.Context.Students.ToArray();
            var courses = this.Context.Courses.ToList();
            List<Course> enrolledCourses = new List<Course>();

            for (int i = 0; i < courses.Count(); i++)
            {
                var studentsBuffer = courses[i].Students.ToArray();

                for (int j = 0; j < studentsBuffer.Count(); j++)
                {
                    if (studentsBuffer[j].User.Id.ToString() == currentUser.Id.ToString())
                    {
                        enrolledCourses.Add(courses[i]);
                    }

                }
            }

            //
            //test end
            vm.EnrolledCourses = Mapper.Map<IEnumerable<Course>, IEnumerable<UserCourseVM>>(enrolledCourses.AsEnumerable());
            return vm;
        }

        public void EditUser(EditUserVM model, string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            user.Name = model.Name;
            user.Email = model.Email;

            this.Context.SaveChanges();
        }

        public EditUserVM GetEditVM(string userName)
        {
            ApplicationUser user = this.Context.Users.FirstOrDefault(applicationUser => applicationUser.UserName == userName);
            EditUserVM vm = Mapper.Map<ApplicationUser, EditUserVM>(user);
            return vm;
        }
    }
}

using AutoMapper;
using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Models.ViewModels.Users;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LearningSystem.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            ConfigureMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void ConfigureMappings()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Course, DetailsCourseVM>();
                expression.CreateMap<Course, CourseVM>();
                expression.CreateMap<ApplicationUser, ProfileVM>();
                expression.CreateMap<Course, UserCourseVM>();
                expression.CreateMap<ApplicationUser, EditUserVM>();
                expression.CreateMap<Article, ArticleVM>();
                expression.CreateMap<ApplicationUser, ArticleAuthorVM>();
                expression.CreateMap<AddArticleVM, Article>();
                expression.CreateMap<Student, AdminPageUserVM>().ForMember(vm => vm.Name,
                    configurationExpression =>
                    configurationExpression.MapFrom(student => student.User.Name));
                expression.CreateMap<Course, AdminAddEditCourseVM>();
                expression.CreateMap<Student, AdminEditUserVM>().ForMember(vm => vm.Name,
                    configurationExpression =>
                    configurationExpression.MapFrom(student => student.User.Name));
            });
        }
    }
}

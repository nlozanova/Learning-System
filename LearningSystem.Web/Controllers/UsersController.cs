using LearningSystem.Models.EntityModels;
using LearningSystem.Models.ViewModels.Users;
using System.Web.Mvc;
using LearningSystem.Interfaces.Services;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = "Student")]
    [RoutePrefix("users")]
    public class UsersController : Controller
    {
        private IUsersService service;
        public UsersController(IUsersService service)
        {
            this.service = service;
        }

        [HttpPost]
        [Route("enroll/{courseId}")]
        public ActionResult Enroll(int courseId)
        {
            string userName = User.Identity.Name;
            Student student = this.service.GetCurrentStudent(userName);
            this.service.EnrollStudentInCourse(courseId, student);
            return RedirectToAction("UserProfile"); ;
        }

        [Route("userProfile")]
        public ActionResult UserProfile()
        {
            string userName = this.User.Identity.Name;
            ProfileVM vm = this.service.GetProfileVM(userName);
            return this.View(vm);
        }

        [HttpGet]
        [Route("edit")]

        public ActionResult Edit()
        {
            string userName = this.User.Identity.Name;
            EditUserVM vm = this.service.GetEditVM(userName);

            return this.View(vm);
        }

        [HttpPost]
        [Route("edit")]
        public ActionResult Edit(EditUserVM model)
        {
            string userName = this.User.Identity.Name;
            if (this.ModelState.IsValid)
            {
                this.service.EditUser(model, userName);

                return this.RedirectToAction("UserProfile");

            }
            return this.View();
        }
    }
}
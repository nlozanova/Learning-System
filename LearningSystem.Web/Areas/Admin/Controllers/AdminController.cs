using LearningSystem.Interfaces.Services;
using LearningSystem.Models.ViewModels.Admin;
using LearningSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [RouteArea("Admin")]
    public class AdminController : Controller
    {
        private IAdminService service;

        public AdminController(IAdminService service)
        {
            this.service = service;
        }
        [Route]
        public ActionResult Index()
        {
            AdminPageVM vm = this.service.GetAdminPage();
            return View(vm);
        }

        [Route("course/add")]
        public ActionResult AddCourse()
        {
            AdminAddEditCourseVM vm = new AdminAddEditCourseVM();
            vm.Trainers = this.service.GetCourseTrainers();
            return this.View(vm);
        }

        [Route("course/add")]
        [HttpPost]
        public ActionResult AddCourse(AdminAddEditCourseVM model)
        {
            if (ModelState.IsValid)
            {
                this.service.AddCourse(model);
                return RedirectToAction("Index");
            }

            return this.View(model);
        }

        [Route("course/{id}/edit")]
        public ActionResult EditCourse(int id)
        {
            AdminAddEditCourseVM vm = service.GetEditCourse(id);
            vm.Trainers = this.service.GetCourseTrainers();
            return this.View(vm);
        }

        [HttpPost]
        [Route("course/{id}/edit")]
        public ActionResult EditCourse(AdminAddEditCourseVM model)
        {
            if (ModelState.IsValid)
            {
                this.service.EditCourse(model);
                return this.RedirectToAction("Index");
            }
            AdminAddEditCourseVM vm = service.GetEditCourse(model.Id);
            return this.View(vm);
        }

        [Route("users/{id}/edit")]
        public ActionResult EditUser(int id)
        {
            AdminEditUserVM vm = service.GetEditUserVM(id);
            return this.View(vm);
        }

        [Route("users/{id}/edit")]
        [HttpPost]
        public ActionResult EditUser(AdminEditUserVM model)
        {
            if (ModelState.IsValid)
            {
                this.service.EditUser(model);
                return this.RedirectToAction("Index");

            }
            AdminEditUserVM vm = service.GetEditUserVM(model.Id);
            return this.View(vm);
        }
    }
}
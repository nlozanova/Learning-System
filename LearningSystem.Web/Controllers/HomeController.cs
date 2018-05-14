﻿using LearningSystem.Interfaces.Services;
using LearningSystem.Models.ViewModels.Courses;
using LearningSystem.Services;
using LearningSystem.Web.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Controllers
{
    [Authorize(Roles = "Student")]
    public class HomeController : Controller
    {
        private IHomeService service;
        
        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            IEnumerable<CourseVM> vms = this.service.GetAllCources();
            return View(vms);
        }

        //[Route("upload")]
        //[HttpGet]
        //public ActionResult UploadFile()
        //{
        //    return this.View();
        //}

        //[HttpPost]
        //[Route("upload")]
        //[ActionName("UploadFile")]
        //public ActionResult UploadFile()
        //{
        //    HttpPostedFileBase file = this.Request.Files[0];
        //    string fileName = Path.GetFileName(file.FileName);
        //    string path = Path.Combine(Server.MapPath("~/UploadedFiles"), fileName);
        //    file.SaveAs(path);
        //    return this.RedirectToAction("Index");
        //}

    }
}
using LearningSystem.Interfaces.Services;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LearningSystem.Web.Areas.Blog.Controllers
{
    [Authorize(Roles = "Student")]
    [RouteArea("Blog")]
    public class BlogController : Controller
    {
        private IBlogService service;

        public BlogController(IBlogService service)
        {
            this.service = service;
        }

        [Route("Articles")]
        public ActionResult Articles()
        {
            IEnumerable<ArticleVM> vms = this.service.GetArticles();
            return this.View(vms);
        }

        [HttpGet]
        [Authorize(Roles = "BlogAuthor")]
        [Route("Articles/Add")]
        public ActionResult Add()
        {
            return this.View();
        }

        [HttpPost]
        [Authorize(Roles = "BlogAuthor")]
        [Route("Articles/Add")]
        public ActionResult Add(AddArticleVM model)
        {
            if (this.ModelState.IsValid)
            {
                string username = this.User.Identity.Name;
                this.service.AddNewArticle(model, username);
                return RedirectToAction("Articles");

            }
            return this.View();
        }
    }
}
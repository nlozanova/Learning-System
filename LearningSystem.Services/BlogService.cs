using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningSystem.Models.ViewModels.Blog;
using LearningSystem.Models.EntityModels;
using AutoMapper;
using LearningSystem.Interfaces.Services;

namespace LearningSystem.Services
{
    public class BlogService : Service, IBlogService
    {
        public IEnumerable<ArticleVM> GetArticles()
        {
            IEnumerable<Article> models = this.Context.Articles;
            IEnumerable<ArticleVM> vms = Mapper.Map<IEnumerable<Article>, IEnumerable<ArticleVM>>(models);

            return vms;
        }

        public void AddNewArticle(AddArticleVM model, string username)
        {
            ApplicationUser currentUser = this.Context.Users.FirstOrDefault(user => user.UserName == username);

            Article article = Mapper.Map<AddArticleVM, Article>(model);
            article.Author = currentUser;
            article.PublishDate = DateTime.Today;
            this.Context.Articles.Add(article);
            this.Context.SaveChanges();
        }
    }
}

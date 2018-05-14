using System.Collections.Generic;
using LearningSystem.Models.ViewModels.Blog;

namespace LearningSystem.Interfaces.Services
{
    public interface IBlogService
    {
        void AddNewArticle(AddArticleVM model, string username);
        IEnumerable<ArticleVM> GetArticles();
    }
}
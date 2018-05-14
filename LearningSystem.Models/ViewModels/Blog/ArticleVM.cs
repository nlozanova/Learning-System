using LearningSystem.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningSystem.Models.ViewModels.Blog
{
    public class ArticleVM
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public ArticleAuthorVM Author { get; set; }
    }
}

namespace LearningSystem.Data
{
    using LearningSystem.Models.EntityModels;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class LearningSystemContext : IdentityDbContext<ApplicationUser>
    {       
        public LearningSystemContext()
             : base("LearningSystem")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Article> Articles { get; set; }

        public static LearningSystemContext Create()
        {
            return new LearningSystemContext();
        }
    }
}
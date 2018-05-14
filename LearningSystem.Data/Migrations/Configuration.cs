namespace LearningSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using LearningSystem.Models.EntityModels;

    internal sealed class Configuration : DbMigrationsConfiguration<LearningSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }
        
        protected override void Seed(LearningSystemContext context)
        {
            if (!context.Roles.Any(role => role.Name == "Student"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Student");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Trainer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Trainer");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("Admin");
                manager.Create(role);
            }

            if (!context.Roles.Any(role => role.Name == "BlogAuthor"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole("BlogAuthor");
                manager.Create(role);
            }
            context.Courses.AddOrUpdate(course => course.Name, new Course[]
                {
                    new Course()
                    {
                        Name = "Programming basics - March 2016",
                        Description = "Description",
                        StartDate = new DateTime (2016, 03, 23),
                        EndDate = new DateTime (2016, 05, 23)
                    },
                     new Course()
                    {
                        Name = "Software technologies",
                        Description = "Description",
                        StartDate = new DateTime (2017, 03, 23),
                        EndDate = new DateTime (2017, 05, 23)
                    },
                      new Course()
                    {
                        Name = "Arduino controllers",
                        Description = "Description",
                        StartDate = new DateTime (2016, 02, 14),
                        EndDate = new DateTime (2016, 03, 20)
                    },
                       new Course()
                    {
                        Name = "Cake making",
                        Description = "Description",
                        StartDate = new DateTime (2016, 01, 01),
                        EndDate = new DateTime (2016, 01, 23)
                    },
                        new Course()
                    {
                        Name = "Cockies making",
                        Description = "Description",
                        StartDate = new DateTime (2016, 05, 19),
                        EndDate = new DateTime (2016, 06, 01)
                    }
                });
        }
    }
}

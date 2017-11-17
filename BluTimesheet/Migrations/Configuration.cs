namespace BluTimesheet.Migrations
{
    using BluTimesheet.Authorization;
    using BluTimesheet.Context;
    using BluTimesheet.Models.DbModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity.Owin;
    using System;
    using System.Data.Entity.Migrations;
    using System.Web;

    internal sealed class Configuration : DbMigrationsConfiguration<TimesheetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TimesheetDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            if (!roleManager.RoleExists(Startup.roleAdmin))
            {
                roleManager.Create(new IdentityRole(Startup.roleAdmin));
            }

            if (!roleManager.RoleExists(Startup.roleUser))
            {
                roleManager.Create(new IdentityRole(Startup.roleUser));
            }

            if (!roleManager.RoleExists(Startup.roleManager))
            {
                roleManager.Create(new IdentityRole(Startup.roleManager));
            }


            var userKrzysztof = userManager.FindByEmail("k.kluszczynski@blunovation.com");

            if (userKrzysztof == null)
            {
                userKrzysztof = new ApplicationUser
                {
                    Email = "k.kluszczynski@blunovation.com",
                    UserName = "k.kluszczynski@blunovation.com",
                    FirstName = "Krzysztof",
                    LastName = "Kluszczynski",

                };
                string passwordKrzysztof = "Password1!";
                userManager.Create(userKrzysztof, passwordKrzysztof);
                userManager.AddToRole(userKrzysztof.Id, Startup.roleAdmin);
            }
            

            var userJakub = userManager.FindByEmail("j.wycinka@blunovation.com");
            
            if (userJakub == null)
            {
                userJakub = new ApplicationUser
                {
                    Email = "j.wycinka@blunovation.com",
                    UserName = "j.wycinka@blunovation.com",
                    FirstName = "Jakub",
                    LastName = "Wycinka",

                };
                string passwordJakub = "Password1!";
                userManager.Create(userJakub, passwordJakub);
                userManager.AddToRole(userJakub.Id, Startup.roleUser);
            }


            var userPiotr = userManager.FindByEmail("p.nasinski@blunovation.com");
            
            if (userPiotr == null)
            {
                userPiotr = new ApplicationUser
                {
                    Email = "p.nasinski@blunovation.com",
                    UserName = "p.nasinski@blunovation.com",
                    FirstName = "Piotr",
                    LastName = "Nasiñski",

                };
                string passwordPiotr = "Password1!";
                userManager.Create(userPiotr, passwordPiotr);
                userManager.AddToRole(userPiotr.Id, Startup.roleManager);
            }




            ProjectType projectBillable = new ProjectType { Name = "Billable" };
            ProjectType projectNonBillable = new ProjectType { Name = "Non-Billable" };

            Project project1 = new Project { Name = "Timesheet", ProjectType = projectNonBillable };
            Project project2 = new Project { Name = "Artifex", ProjectType = projectBillable };
            Project project3 = new Project { Name = "DD-PACK", ProjectType = projectBillable };
            Project project4 = new Project { Name = "IMPAQ", ProjectType = projectBillable };


            ActivityType activityType1 = new ActivityType { Name = "Working" };
            ActivityType activityType2 = new ActivityType { Name = "Sickness" };
            ActivityType activityType3 = new ActivityType { Name = "Holidays" };
            ActivityType activityType4 = new ActivityType { Name = "Bank Holidays" };
            ActivityType activityType5 = new ActivityType { Name = "Event" };
            ActivityType activityType6 = new ActivityType { Name = "Other" };


            Activity activity1 = new Activity
            {
                Begining = DateTime.Now,
                Project = project1,
                ActivityType = activityType1,
                UserId = userJakub.Id
            };
            Activity activity2 = new Activity
            {
                Begining = DateTime.Now.AddDays(-1),
                Project = project1,
                ActivityType = activityType1,
                UserId = userJakub.Id
            };
            Activity activity3 = new Activity
            {
                Begining = DateTime.Now.AddDays(-2),
                Project = project1,
                ActivityType = activityType1,
                UserId = userJakub.Id
            };
            Activity activity4 = new Activity
            {
                Begining = DateTime.Now.AddDays(-3),
                Project = project1,
                ActivityType = activityType1,
                UserId = userJakub.Id
            };

            context.ProjectType.AddOrUpdate(x => x.Name, projectBillable, projectNonBillable);
            context.Project.AddOrUpdate(x => x.Name, project1, project2, project3, project4);
            context.ActivityType.AddOrUpdate(x => x.Name, activityType1, activityType2,
                activityType3, activityType4, activityType5, activityType6);
            context.Activity.AddOrUpdate(x => x.Id, activity1, activity2, activity3, activity4);
            context.SaveChanges();
        }
    }
}

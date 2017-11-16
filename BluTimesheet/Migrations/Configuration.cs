namespace BluTimesheet.Migrations
{
    using BluTimesheet.Authorization;
    using BluTimesheet.Models.DbModels;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BluTimesheet.Context.TimesheetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BluTimesheet.Context.TimesheetDbContext context)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

            string roleAdmin = "Admin";
            string roleUser = "User";
            string password = "Password1!";
            string emailJakub = "j.wycinka@blunovation.com";
            string emailKrzysztof = "k.kluszczyñski@blunovation.com";

            if (!roleManager.RoleExists(roleAdmin))
            {
                var roleresult = roleManager.Create(new IdentityRole(roleAdmin));
            }
            
            if (!roleManager.RoleExists(roleUser))
            {
                var roleresult2 = roleManager.Create(new IdentityRole(roleUser));
            }
            
            var userKrzysztof = new ApplicationUser
            {
                Email = emailKrzysztof,
                UserName = emailKrzysztof,
                FirstName = "Krzysztof",
                LastName = "Kluszczyñski",               
                
            };
            var adminresult = userManager.Create(userKrzysztof, password);

            //Add User Admin to Role Admin
            if (adminresult.Succeeded)
            {
                var result = userManager.AddToRole(userKrzysztof.Id, roleAdmin);
            }

            var userJakub = new ApplicationUser
            {
                Email = emailJakub,
                UserName = emailJakub,
                FirstName = "Jakub",
                LastName = "Wycinka",

            };

            var userresult = userManager.Create(userJakub, password);
            if (userresult.Succeeded)
            {
                var result = userManager.AddToRole(userJakub.Id, roleUser);
            }

            ProjectType projectBillable = new ProjectType { Name = "Billable" };
            ProjectType projectNonBillable = new ProjectType { Name = "Non-Billable" };

            Project project1 = new Project { Name = "Timesheet", ProjectType = projectNonBillable };
            Project project2 = new Project { Name = "Artifex", ProjectType = projectBillable };
            Project project3 = new Project { Name = "DD-PACK", ProjectType = projectBillable };
            Project project4 = new Project { Name = "IMPAQ", ProjectType = projectBillable };


            ActivityType activity1 = new ActivityType { Name = "Working" };
            ActivityType activity2 = new ActivityType { Name = "Sickness" };
            ActivityType activity3 = new ActivityType { Name = "Holidays" };
            ActivityType activity4 = new ActivityType { Name = "Bank Holidays" };
            ActivityType activity5 = new ActivityType { Name = "Event" };
            ActivityType activity6 = new ActivityType { Name = "Other" };


            Activity dailyActivity1 = new Activity
            {
                Begining = DateTime.Now,
                Project = project1,
                ActivityType = activity1,
                UserId = userJakub.Id
            };

            context.ProjectType.AddOrUpdate(x => x.Name, projectBillable, projectNonBillable);
            context.Project.AddOrUpdate(x => x.Name, project1, project2);
            context.ActivityType.AddOrUpdate(x => x.Name, activity1, activity2, activity3, activity4, activity5, activity6);
            context.Activity.AddOrUpdate(x => x.End, dailyActivity1);
            context.SaveChanges();
    }
    }
}

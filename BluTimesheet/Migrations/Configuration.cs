namespace BluTimesheet.Migrations
{
    using BluTimesheet.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BluTimesheet.Context.TimesheetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BluTimesheet.Context.TimesheetDbContext context)
        {
            UserType userTypeUser = new UserType { Role = "employee" };
            UserType userTypeAdmin = new UserType { Role = "admin" };
            UserType userTypeManager = new UserType { Role = "manager" };
            UserType userTypeDirector = new UserType { Role = "director" };

            User user1 = new User
            {

                Name = "Jakub",
                Surname = "Wycinka",
                Email = "j.wycinka@blunovation.com",
                UserType = userTypeUser,

            };


            User user2 = new User
            {

                Name = "Krzysztof",
                Surname = "Kluszczyñski",
                Email = "k.kluszczynski@blunovation.com",
                UserType = userTypeAdmin
            };

            ProjectType projectType1 = new ProjectType { Name = "Billable" };
            ProjectType projectType2 = new ProjectType { Name = "Non-Billable" };

            Project project1 = new Project { Name = "Timesheet", ProjectType = projectType2 };
            Project project2 = new Project { Name = "Artifex", ProjectType = projectType1 };
            Project project3 = new Project { Name = "DD-PACK", ProjectType = projectType1 };
            Project project4 = new Project { Name = "IMPAQ", ProjectType = projectType1 };


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
                User = user1,
            };
            
            context.ProjectType.AddOrUpdate(x => x.Name, projectType1, projectType2);
            context.Project.AddOrUpdate(x => x.Name, project1, project2);
            context.UserType.AddOrUpdate(x => x.Role, userTypeUser, userTypeAdmin, userTypeManager, userTypeDirector);
            context.User.AddOrUpdate(x => x.Name, user1, user2);
            context.ActivityType.AddOrUpdate(x => x.Name, activity1, activity2, activity3, activity4, activity5, activity6);
            context.Activity.AddOrUpdate(x => x.End, dailyActivity1);
            context.SaveChanges();

        }
    }
}

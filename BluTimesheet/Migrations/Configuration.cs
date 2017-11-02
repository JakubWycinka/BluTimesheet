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
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BluTimesheet.Context.TimesheetDbContext context)
        {
            UserType userTypeUser = new UserType { Role = "user"};
            UserType userTypeAdmin = new UserType { Role = "admin" };
            
            User user1 = new User
            {
                Name = "Jakub",
                Surname = "Wycinka",
                Email = "j.wycinka@blunovation.com",
                Password = "00000",
                UserType = userTypeUser
            };

            User user2 = new User
            {
                Name = "Krzysztof",
                Surname = "Kluczyñski",
                Email = "k.kluczynski@blunovation.com",
                Password = "00000",
                UserType = userTypeAdmin                
            };

            ProjectType projectType1 = new ProjectType { Name = "Billable" };
            ProjectType projectType2 = new ProjectType { Name = "Non-Billable" };

            Project project1 = new Project { Name = "Timesheet", ProjectType = projectType2 };
            Project project2 = new Project { Name = "Artifex", ProjectType = projectType1 };


            Activity activity1 = new Activity { Name = "Working"};
            Activity activity2 = new Activity { Name = "Sickness" };
            Activity activity3 = new Activity { Name = "Holidays" };
            Activity activity4 = new Activity { Name = "Bank Holidays" };
            Activity activity5 = new Activity { Name = "Event" };
            Activity activity6 = new Activity { Name = "Other" };

            DailyActivity dailyActivity1 = new DailyActivity
            {
                BeginingHour = 7, BeginingMinute = 0, EndingHour = 15, EndingMinute= 0, Date = 
                

            };



            context.ProjectType.AddOrUpdate(p => p.Id, projectType1, projectType2);
            context.Project.AddOrUpdate(p => p.Id, project1);
            context.UserType.AddOrUpdate(u => u.Id, userTypeUser, userTypeAdmin);
            context.User.AddOrUpdate(u => u.Id,user1,user2);      

        }
    }
}

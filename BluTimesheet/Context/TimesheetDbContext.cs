using BluTimesheet.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BluTimesheet.Context
{
    public class TimesheetDbContext : IdentityDbContext
    {
        public TimesheetDbContext() : base()
        {
        }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<IdentityUser>()
                .ToTable("Users");
            modelBuilder.Entity<User>()
                .ToTable("Users");
        }

        public static TimesheetDbContext Create()
        {
            return new TimesheetDbContext();
        }
    }
}
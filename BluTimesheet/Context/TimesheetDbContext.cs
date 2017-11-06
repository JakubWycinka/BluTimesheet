using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BluTimesheet.Context
{
    public class TimesheetDbContext : DbContext
    {
        public TimesheetDbContext() : base("TimesheetDbContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserType> UserType { get; set; }
        public DbSet<Project> Project { get; set; }
        public DbSet<ProjectType> ProjectType { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<TimesheetDbContext>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}
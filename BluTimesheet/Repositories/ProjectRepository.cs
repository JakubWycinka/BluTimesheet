using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class ProjectRepository : IDisposable
    {
        private TimesheetDbContext context;

        public ProjectRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(Project project)
        {
            context.Project.Add(project);
            context.SaveChanges();
        }

        public Project Get(int id)
        {
            return context.Project.Find(id);
        }

        public void Remove(int id)
        {
            Project tempProject = new Project
            {
                Id = id
            };
            context.Project.Remove(tempProject);
            context.SaveChanges();
        }

        public void Update(Project project)
        {
            var projectFromDb = context.Project.SingleOrDefault(projectInDb => projectInDb.Id == project.Id);
            if (projectFromDb != null)
            {
                
                projectFromDb.Name = project.Name;
                projectFromDb.ProjectType = project.ProjectType;
                context.SaveChanges();
            }

        }

        public IEnumerable<Project> GetAll()
        {
            return context.Project.AsEnumerable<Project>();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
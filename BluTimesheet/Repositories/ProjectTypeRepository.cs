using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class ProjectTypeRepository : IDisposable
    {
        private TimesheetDbContext context;

        public ProjectTypeRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(ProjectType projectType)
        {
            context.ProjectType.Add(projectType);
        }

        public ProjectType GetById(int projectTypeId)
        {
            return context.ProjectType.Find(projectTypeId);
        }

        public void RemoveById(int projectTypeId)
        {
            ProjectType tempProjectType = new ProjectType
            {
                Id = projectTypeId
            };
            context.ProjectType.Remove(tempProjectType);
        }

        public void Update(ProjectType projectType)
        {
            var projectTypeFromDb = context.ProjectType.SingleOrDefault(projectTypeInDb => projectTypeInDb.Id == projectType.Id);
            if (projectTypeFromDb != null)
            {

                projectTypeFromDb.Name = projectType.Name;                
                context.SaveChanges();
            }

        }

        public List<ProjectType> GetProjectTypes()
        {
            return context.ProjectType.ToList();
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
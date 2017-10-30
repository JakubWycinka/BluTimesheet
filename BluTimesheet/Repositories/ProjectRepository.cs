using BluTimesheet.Context;
using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Repositories
{
    public class ProjectRepository 
    {
        private readonly TimesheetDbContext context;

        public ProjectRepository(TimesheetDbContext context)
        {
            this.context = context;
        }

        public void Add(Project project)
        {
            context.Project.Add(project);
        }

        public Project GetById(int projectId)
        {
            return context.Project.Find(projectId);
        }

        public void RemoveById(int projectId)
        {
            Project tempProject = new Project
            {
                Id = projectId
            };
            context.Project.Remove(tempProject);
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

        public List<Project> GetProjects()
        {
            return context.Project.ToList();
        }



    }
}
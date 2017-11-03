using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BluTimesheet.Models;

namespace BluTimesheet.Services.implementations
{
    public class ProjectTypeService : IProjectTypeService
    {
        private readonly ProjectTypeRepository projectTypeRepository;

        public ProjectTypeService(ProjectTypeRepository projectTypeRepository)
        {
            this.projectTypeRepository = projectTypeRepository;
        }

        public void Add(ProjectType projectType)
        {
            projectTypeRepository.Add(projectType);
        }

        public ProjectType Get(int id)
        {
            return projectTypeRepository.Get(id);
        }

        public IEnumerable<ProjectType> GetAll()
        {
            return projectTypeRepository.GetAll();
        }

        public IEnumerable<Project> GetProjects(int id)
        {
            return Get(id).Project;
        }

        public void Remove(int id)
        {
            projectTypeRepository.Remove(id);
        }

        public void Update(ProjectType projectType)
        {
            projectTypeRepository.Update(projectType);
        }
    }
}
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

        public ProjectType Get(int projectTypeId)
        {
            return projectTypeRepository.Get(projectTypeId);
        }

        public IEnumerable<ProjectType> GetAll()
        {
            return projectTypeRepository.GetAll();
        }

        public void Remove(int projectTypeId)
        {
            projectTypeRepository.Remove(projectTypeId);
        }

        public void Update(ProjectType projectType)
        {
            projectTypeRepository.Update(projectType);
        }
    }
}
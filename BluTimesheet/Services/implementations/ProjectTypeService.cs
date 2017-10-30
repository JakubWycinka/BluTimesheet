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

        public void AddProjectType(ProjectType projectType)
        {
            projectTypeRepository.Add(projectType);
        }

        public ProjectType GetProjectTypeById(int projectTypeId)
        {
            return projectTypeRepository.GetById(projectTypeId);
        }

        public List<ProjectType> GetProjectTypes()
        {
            return projectTypeRepository.GetProjectTypes();
        }

        public void RemoveProjectTypeById(int projectTypeId)
        {
            projectTypeRepository.RemoveById(projectTypeId);
        }

        public void UpdateProjectType(ProjectType projectType)
        {
            projectTypeRepository.Update(projectType);
        }
    }
}
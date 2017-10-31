using System.Collections.Generic;
using BluTimesheet.Models;
using BluTimesheet.Repositories;
using BluTimesheet.Services.interfaces;

namespace BluTimesheet.Services.implementations
{
    public class ProjectService : IProjectService
    {
        private readonly ProjectRepository projectRepository;

        public ProjectService(ProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public void AddProject(Project project)
        {
            projectRepository.Add(project);
        }

        public Project GetProjectById(int projectId)
        {
            return projectRepository.GetById(projectId);
        }

        public List<Project> GetProjects()
        {
            return projectRepository.GetProjects();
        }

        public void RemoveProjectById(int projectId)
        {
            projectRepository.RemoveById(projectId);
        }

        public void UpdateProject(Project project)
        {
            projectRepository.Update(project);
        }
    }
}
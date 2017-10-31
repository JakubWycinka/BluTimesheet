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

        public void Add(Project project)
        {
            projectRepository.Add(project);
        }

        public Project Get(int projectId)
        {
            return projectRepository.Get(projectId);
        }

        public IEnumerable<Project> GetAll()
        {
            return projectRepository.GetAll();
        }

        public void Remove(int projectId)
        {
            projectRepository.Remove(projectId);
        }

        public void Update(Project project)
        {
            projectRepository.Update(project);
        }
    }
}
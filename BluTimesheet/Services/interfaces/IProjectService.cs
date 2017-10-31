using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Services.interfaces
{
    public interface IProjectService
    {
        void AddProject(Project project);
        void RemoveProjectById(int projectId);
        Project GetProjectById(int projectId);
        void UpdateProject(Project project);
        List<Project> GetProjects();
    }
}
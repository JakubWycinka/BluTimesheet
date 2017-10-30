using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluTimesheet.Services.interfaces
{
    public interface IProjectTypeService
    {
        void AddProjectType(ProjectType projectType);
        void RemoveProjectTypeById(int projectTypeId);
        ProjectType GetProjectTypeById(int projectTypeId);
        void UpdateProjectType(ProjectType projectType);
        List<ProjectType> GetProjectTypes();
    }
}

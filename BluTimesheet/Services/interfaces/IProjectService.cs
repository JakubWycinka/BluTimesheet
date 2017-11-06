using BluTimesheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BluTimesheet.Services.interfaces
{
    public interface IProjectService
    {
        void Add(Project project);
        void Remove(int id);
        Project Get(int id);
        void Update(Project project);
        IEnumerable<Project> GetAll();
        IEnumerable<Project> GetProjectsByProjectType(int id);
    }
}
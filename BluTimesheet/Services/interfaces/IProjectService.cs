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
        void Remove(int projectId);
        Project Get(int projectId);
        void Update(Project project);
        IEnumerable<Project> GetAll();
    }
}
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
        void Add(ProjectType projectType);
        void Remove(int projectTypeId);
        ProjectType Get(int projectTypeId);
        void Update(ProjectType projectType);
        IEnumerable<ProjectType> GetAll();
    }
}

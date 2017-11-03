using BluTimesheet.Models;
using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class ProjectTypeController : ApiController
    {
        private readonly IProjectTypeService projectTypeService;

        public ProjectTypeController(IProjectTypeService projectTypeService)
        {
            this.projectTypeService = projectTypeService;
        }

    
        public IHttpActionResult PostProjectType(ProjectType projectType)
        {
            projectTypeService.Add(projectType);
            return Ok();
        }

        public IEnumerable<ProjectType> GetProjectTypes()
        {
            return projectTypeService.GetAll();
        }

        public IHttpActionResult GetProjectType(int id)
        {
            var projectType = projectTypeService.Get(id);
            if (projectType != null)
            {
                return Ok(projectType);
            } else
            {
                return NotFound();
            }
            
        }

        public IHttpActionResult PutProjectType(ProjectType projectType)
        {
            projectTypeService.Update(projectType);
            return Ok();
        }

        public IHttpActionResult DeleteProjectType(int id)
        {
            projectTypeService.Remove(id);
            return Ok();
        }

        [Route("api/projecttype/projects")]
        public IEnumerable<Project> GetProjects(int id)
        {
            return projectTypeService.GetProjects(id);
        }

    }
}

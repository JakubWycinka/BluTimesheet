using BluTimesheet.Services.interfaces;
using System.Collections.Generic;
using System.Web.Http;
using BluTimesheet.Models.DbModels;

namespace BluTimesheet.Controllers
{
    public class ProjectController : ApiController
    {
        private IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }


        public IHttpActionResult PostProject(Project project)
        {
            projectService.Add(project);
            return Ok();
        }

        public IEnumerable<Project> GetProjects()
        {
            return projectService.GetAll();
        }

        [Route("api/projecttype/{id}/projects")]
        public IEnumerable<Project> GetProjectsByProjectType(int id)
        {
            return projectService.GetProjectsByProjectType(id);
        }

        public IHttpActionResult GetProject(int id)
        {
            var project = projectService.Get(id);
            if (project != null)
            {
                return Ok(project);
            }
            else
            {
                return NotFound();
            }

        }

        public IHttpActionResult PutProject(Project project)
        {
            projectService.Update(project);
            return Ok();
        }

        public IHttpActionResult DeleteProject(int id)
        {
            projectService.Remove(id);
            return Ok();
        }
    }
}

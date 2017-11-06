using BluTimesheet.Models;
using BluTimesheet.Services.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BluTimesheet.Controllers
{
    public class ProjectController : ApiController
    {
        private readonly IProjectService projectService;

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

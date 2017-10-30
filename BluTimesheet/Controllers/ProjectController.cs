using BluTimesheet.Controllers.interfaces;
using BluTimesheet.Models;
using BluTimesheet.Services;
using BluTimesheet.Services.implementations;
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
        private readonly IProjectTypeService projectTypeService;

        public ProjectController(IProjectService projectService, IProjectTypeService projectTypeService)
        {
            this.projectService = projectService;
            this.projectTypeService = projectTypeService;
        }


        [Route("api/project/add")]
        [HttpPost]
        public HttpResponseMessage Add(Project project)
        {
            projectService.AddProject(project);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [Route("api/project/addtype")]
        [HttpPost]
        public HttpResponseMessage AddType(ProjectType projectType)
        {
            projectTypeService.AddProjectType(projectType);

            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}

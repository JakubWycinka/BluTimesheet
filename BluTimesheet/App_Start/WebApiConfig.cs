using BluTimesheet.Controllers;
using BluTimesheet.Controllers.interfaces;
using BluTimesheet.Services;
using BluTimesheet.Services.implementations;
using BluTimesheet.Services.interfaces;
using BluTimesheet.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.AspNet.WebApi;
using BluTimesheet.Utils;

namespace BluTimesheet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //Dependecy Injection
            var container = new UnityContainer();
            container.RegisterType<IActivityService, ActivityService>();
            container.RegisterType<IDailyActivityService, DailyActivityService>();
            container.RegisterType<IProjectTypeService, ProjectTypeService>();
            container.RegisterType<IProjectService, ProjectService>();
            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IUserTypeService, UserTypeService>();
            config.DependencyResolver = new UnityDependencyResolver(container);

            //Global validation
            config.Filters.Add(new ValidateModelAttribute());

            //Global Authorization
            //config.Filters.Add(new AuthorizeAttribute());

            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new {id = RouteParameter.Optional}
            );
        }
    }
}

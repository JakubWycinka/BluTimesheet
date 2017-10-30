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

namespace BluTimesheet
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            var container = new UnityContainer();
            container.RegisterType<IProjectTypeService, ProjectTypeService>(new HierarchicalLifetimeManager());
            
           config.DependencyResolver = new UnityDependencyResolver(container);






            //Add any additional configuration code.

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
         

        }
    }
}

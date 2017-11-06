﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using BluTimesheet.Controllers.interfaces;
using BluTimesheet.Services;
using BluTimesheet.Services.implementations;
using BluTimesheet.Services.interfaces;
using Unity;
using Newtonsoft.Json;

namespace BluTimesheet
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //var json = GlobalConfiguration.Configuration.Formatters.JsonFormatter;
            //json.SerializerSettings.PreserveReferencesHandling =
            //   Newtonsoft.Json.PreserveReferencesHandling.All;

            GlobalConfiguration.Configuration.Formatters
                  .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
                  = ReferenceLoopHandling.Ignore;

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
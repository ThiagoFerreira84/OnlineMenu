using AutoMapper;

//using OnlineMenu.Service.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace OnlineMenu
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //Register Mapping
            //Mapper.Initialize(cfg => cfg.AddProfile<Service.Mapping.AutoMapperProfile>());

            //Register Unity
            //Service.DI.UnityConfig.RegisterComponents();
        }

        protected void Session_Start(Object sender, EventArgs e)
        {
            //Set User or replaced user
            //AppManager.SetCurrentUserInfo(string.Empty);

            //Set information about Server and Database
            //AppManager.SetEnvironmentSessions();

            // Register global filter
            //GlobalFilters.Filters.Add(new ActionFilter());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Blog.DAL;
using System.Data.Entity.Infrastructure.Interception;

namespace Blog
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            DbInterception.Add(new BlogInterceptorTransientErrors());
            DbInterception.Add(new BlogInterceptorLogging());
        }
    }
}

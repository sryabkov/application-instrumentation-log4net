using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;

namespace AspNetTraceAppender
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (MvcApplication));

        protected void Application_Start()                
        {
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected void Application_BeginRequest()
        {
            Log.InfoFormat( "Begin request on thread [{0}]", Thread.CurrentThread.ManagedThreadId );
        }

        protected void Application_EndRequest()
        {
            Log.InfoFormat("End request on thread [{0}]", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AwesomeWebsite.Controllers
{
    public class HomeController : Controller
    {
        private static log4net.ILog Log = log4net.LogManager.GetLogger(typeof(HomeController));
        
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            base.Initialize(requestContext);
            
            //Log.Info(Request);            
            log4net.ThreadContext.Properties["request"] = Request;
        }

        public ActionResult Index()
        {
            Log.Info( "Executing Index action on Home controller...");
            
            return View();
        }

    }
}

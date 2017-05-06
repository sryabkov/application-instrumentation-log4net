using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace TelnetAppender.Controllers
{
    public class HomeController : Controller
    {
        private static ILog Log = LogManager.GetLogger(typeof (HomeController));

        public ActionResult Index()
        {
            this.ControllerContext.HttpContext.Trace.Write("tracing ...");
            Trace.Write( "testing");

            Log.Info("Processing Index action...");
            return View();
        }

    }
}

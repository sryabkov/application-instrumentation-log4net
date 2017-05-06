using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;

namespace AspNetTraceAppender.Controllers
{
    public class HomeController : Controller
    {
        private static ILog Log = LogManager.GetLogger(typeof (HomeController));

        public ActionResult Index()
        {
            Log.Info("Processing Index action...");
            return View();
        }

        public ActionResult Warn()
        {
            Log.Error("this action hasn't been coded yet...");
            return View();
        }

    }
}

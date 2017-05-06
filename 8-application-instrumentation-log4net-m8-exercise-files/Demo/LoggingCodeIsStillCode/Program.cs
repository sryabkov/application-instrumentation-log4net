using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace LoggingCodeIsStillCode
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            Log.DebugFormat( "starting program with this length argument: [{0}]", args[0].Length );

            // ...
        }
    }
}

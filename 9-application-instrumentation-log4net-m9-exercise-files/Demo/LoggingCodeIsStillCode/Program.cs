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
            Log.DebugFormat( "starting program with [{0}] arguments", args[0].Length );

            // ...
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NamingConvention.Utility
{
    class OtherLogger
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(OtherLogger));
        
        public void LogThings()
        {
            const string format = "This is a [{0}] level logging event";
            log.DebugFormat(format, "Debug");
            log.InfoFormat(format, "Info");
            log.WarnFormat(format, "Warn");
            log.ErrorFormat(format, "Error");
            log.FatalFormat(format, "Fatal");
        }
    }
}

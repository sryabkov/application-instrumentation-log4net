using System;

[assembly:log4net.Config.XmlConfigurator]

namespace MultipleLoggerObjects
{    
    class Program
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));
        
        static void Main()
        {
            const string format = "This is a [{0}] level logging event";
            log.DebugFormat(format, "Debug");
            log.InfoFormat(format, "Info");
            log.WarnFormat(format, "Warn");
            log.ErrorFormat(format, "Error");
            log.FatalFormat(format, "Fatal");
            
            var logger = new OtherLogger();
            logger.LogThings();

            Console.ReadLine();
        }
    }
}

using System;

namespace LoggerVerbosity
{
    class Program
    {
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

            const string format = "This is a [{0}] level logging event";
            
            log.DebugFormat(format, "Debug");

            log.InfoFormat(format, "Info");

            log.WarnFormat(format, "Warn");

            log.ErrorFormat(format, "Error");

            log.FatalFormat(format, "Fatal");

            Console.ReadLine();
        }
    }
}

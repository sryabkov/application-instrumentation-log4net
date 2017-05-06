using System;
using System.Threading;

namespace LoggerVerbosity
{
    class Program
    {
        static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

            log.Info("Program started.");

            if (log.IsDebugEnabled)
            {
                log.DebugFormat("Expensive calculation result: {0}", CalculateExpensiveResult());
            }

            log.Info("Program complete.");
            
            Console.ReadLine();
        }

        private static int CalculateExpensiveResult()
        {
            Thread.Sleep( 5000 );
            return 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace EventContext
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            using (log4net.ThreadContext.Stacks["methodname"].Push("Main"))
            {
                Log.Info("This is an information log message");

                LogIt();
            }

            Console.ReadLine();
        }

        private static void LogIt()
        {
            using (log4net.ThreadContext.Stacks["methodname"].Push("LogIt"))
            {
                Log.Info("This is an information log message");
            }
        }
    }
}

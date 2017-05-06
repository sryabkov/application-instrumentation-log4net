using System;
using System.Collections.Generic;
using System.Linq;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace RollingFileAppender
{
    static class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main()
        {
            Log.Debug("Starting program");

            while (!Console.KeyAvailable)
            {
                Log.InfoFormat("The current date & time is: [{0}]", DateTime.Now);
                System.Threading.Thread.Sleep(100);
            }

            Log.Debug("Exiting program");
        }
    }
}

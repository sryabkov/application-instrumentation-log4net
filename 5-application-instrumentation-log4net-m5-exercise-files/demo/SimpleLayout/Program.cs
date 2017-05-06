using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace SimpleLayout
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            Log.Debug("Debug message...");
            Log.Info("Info message...");
            Log.Warn("Warn message...");
            Log.Error("Error message...");
            Log.Fatal("Fatal message...");
            Log.Error( "Another Error!", new ApplicationException("Massive Errors Happening Here"));

            Console.ReadLine();
        }
    }
}

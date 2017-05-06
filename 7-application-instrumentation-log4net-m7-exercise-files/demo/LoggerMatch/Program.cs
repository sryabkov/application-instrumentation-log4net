using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace Filters
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));
        private static ILog OtherLog = LogManager.GetLogger("Custom.Logger.Name");

        static void Main(string[] args)
        {
            Log.Debug( "This is a debug message" );
            Log.Info("This is a info message");
            Log.Warn("This is a warn message");
            Log.Error("This is a error message");
            Log.Fatal("This is a fatal message");

            OtherLog.Debug("This is another debug message");
            OtherLog.Info("This is another info message");
            OtherLog.Warn("This is another warn message");
            OtherLog.Error("This is another error message");
            OtherLog.Fatal("This is another fatal message");
            
            Console.ReadLine();
        }
    }
}


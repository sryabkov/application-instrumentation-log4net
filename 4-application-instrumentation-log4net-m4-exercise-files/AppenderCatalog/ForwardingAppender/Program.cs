using System;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace ForwardingAppender
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static readonly ILog SpecialLog = LogManager.GetLogger("SpecialLogger");

        private static void Main(string[] args)
        {
            Log.Debug("Debug message...");
            Log.Info("Info message...");
            Log.Warn("Warn message...");
            Log.Error("Error message...");
            Log.Fatal("Fatal message...");

            SpecialLog.Debug("This is a Special Debug message...");
            SpecialLog.Info("This is a Special Info message...");
            SpecialLog.Warn("This is a Special Warn message...");
            SpecialLog.Error("This is a Special Error message...");
            SpecialLog.Fatal("This is a Special Fatal message...");

            Console.ReadLine();
        }
    }
}

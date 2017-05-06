using System;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace ConsoleAppenders
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        private static void Main(string[] args)
        {
            Log.Debug("Debug message...");
            Log.Info("Info message...");
            Console.WriteLine("The current Date & Time is " + DateTime.Now);
            Log.Warn("Warn message...");
            Log.Error("Error message...");
            Log.Fatal("Fatal message...");

            Console.ReadLine();
        }
    }
}

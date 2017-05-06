using System;

namespace ILogInterface
{
    class Program
    {
        private static void Main()
        {
            log4net.Config.XmlConfigurator.Configure();
            log4net.ILog log = log4net.LogManager.GetLogger(typeof (Program));
            
            log.Debug("This is a Debug level logging event");

            log.Info("This is a Info level logging event");

            log.Warn("This is a Warn level logging event");

            log.Error("This is a Error level logging event");

            log.Fatal("This is a Fatal level logging event");
            
            Console.ReadLine();
        }
    }
}

using System;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using log4net.Repository.Hierarchy;

namespace ConfigureInCode
{
    class Program
    {
        static void Main()
        {
            SimpleLayout layout = new SimpleLayout();
            layout.ActivateOptions();

            ConsoleAppender appender = new ConsoleAppender(); 
            appender.Layout = layout;
            appender.ActivateOptions();

            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            Logger root = hierarchy.Root;
            
            root.Level = log4net.Core.Level.All;

            BasicConfigurator.Configure(appender);

            ILog log = LogManager.GetLogger(typeof(Program));

            log.Debug("Debug");
            log.Info("Info");
            log.Warn("Warn");
            log.Error("Error");
            log.Fatal("Fatal");

            Console.ReadLine();
        }
    }
}

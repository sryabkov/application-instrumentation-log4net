using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace EventContext
{
    class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["WindowTitle"] = Process.GetCurrentProcess().MainWindowTitle;

            Log.Info("This is an information log message");
            
            Console.ReadLine();
        }
    }
}

using System;
using System.Threading;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace BufferingForwardingAppender
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        
        private static void Main(string[] args)
        {
            for (int i = 0; i < 1055; ++i)
            {
                Log.InfoFormat("Info message [{0}]", i);
                Thread.Sleep(10);
            }

            Console.ReadLine();
        }
    }
}

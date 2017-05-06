using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace LossyLogging
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        static void Main(string[] args)
        {
            for (int i = 0; i < 1000; ++i)
            {
                Log.DebugFormat( "Message [{0}]", i );
            }

            Log.Error( "The final error!");
            Console.ReadLine();
        }
    }
}

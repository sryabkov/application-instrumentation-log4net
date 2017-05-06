using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace LoggingNullOrEmptyValues
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main()
        {
            string value = null;
            Log.InfoFormat( "The value is currently {0}", value );
            Console.ReadLine();
        }
    }
}

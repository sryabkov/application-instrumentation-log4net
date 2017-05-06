using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace LoggingingTheUnhandledException
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += LogUnhandledException;

            throw new ApplicationException( "This will end the process!" );
        }

        private static void LogUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Log.Error( 
                String.Format("A {0}fatal unhandled exception has occurred",e.IsTerminating ? String.Empty : "non-"),
                e.ExceptionObject as Exception
            );    
        }
    }
}

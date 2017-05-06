using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace LoggingExceptions
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            try
            {
                DangerousOperation();
            }
            catch (Exception e)
            {
                Log.Error("An exception was thrown while doing the Dangerous Operation", e);                

                //throw;
            }

            Console.ReadLine();
        }

        private static void DangerousOperation()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Globalization;
using System.Threading;
using log4net;

[assembly:log4net.Config.XmlConfigurator]

namespace EventContext
{
    class Program
    {
        private static Random Random = new Random();
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main(string[] args)
        {
            GlobalContext.Properties["ApplicationCulture"] = Thread.CurrentThread.CurrentCulture.EnglishName;
            
            Log.Info("This is an information log message");

            var cultures = CultureInfo.GetCultures(CultureTypes.AllCultures);

            for( int c = 0; c < 5; ++c )
            {
                var thread = new Thread(ThreadEntryPoint);
                
                thread.IsBackground = true;                               
                thread.CurrentCulture = cultures[Random.Next(cultures.Length)]; 

                thread.Start();
            }
            
            Console.ReadLine();
        }

        static void ThreadEntryPoint()
        {            
            ThreadContext.Properties["ThreadCulture"] = Thread.CurrentThread.CurrentCulture.EnglishName;

            Log.Info("This is an information log message from a thread");
        }
    }
}

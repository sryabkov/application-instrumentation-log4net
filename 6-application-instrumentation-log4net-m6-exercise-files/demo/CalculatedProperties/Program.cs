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
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        private static readonly Random Random = new Random();

        static void Main()
        {
            log4net.GlobalContext.Properties["TotalCpuTime"] = new TotalCpuTimeProperty();

            while (!Console.KeyAvailable)
            {
                Log.Info("This is an information log message");

                UseTheCpu();

                Thread.Sleep(1000);
            }

            Console.ReadLine();
        }

        private static void UseTheCpu()
        {
            var numbers = new List<double>();

            for (int i = 0; i < 1000000; ++i)
            {
                numbers.Add(Random.NextDouble());
            }

            numbers.Sort();
        }
    }
}

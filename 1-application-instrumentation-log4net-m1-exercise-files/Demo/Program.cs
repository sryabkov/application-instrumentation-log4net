using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            log4net.Config.BasicConfigurator.Configure();
            var log = log4net.LogManager.GetLogger(typeof (Program));
            log.Info( "Hello from log4net!");
            Console.ReadLine();
        }
    }
}

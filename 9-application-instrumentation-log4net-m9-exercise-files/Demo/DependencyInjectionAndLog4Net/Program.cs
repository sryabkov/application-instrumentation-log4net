using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace DependencyInjectionAndLog4Net
{
    class Program
    {
        static void Main()
        {
            var log = LogManager.GetLogger<Program>();

            log.Info("About to do business!");

            var businessObject = new SuperBusinessObject();
            businessObject.DoBusinessWithDeferredLogging();

            log.Info("Done!");

            Console.ReadLine();

        }
    }
}

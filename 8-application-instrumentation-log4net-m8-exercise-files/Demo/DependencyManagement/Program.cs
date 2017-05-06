using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuperAwesomeApplication
{
    class Program
    {
        static void Main()
        {
            var logManager = new Common.LogManager();
            var log = logManager.GetLogger(typeof (Program));

            log.Info("We're logging without referencing log4net!");

            Console.ReadLine();

        }
    }
}

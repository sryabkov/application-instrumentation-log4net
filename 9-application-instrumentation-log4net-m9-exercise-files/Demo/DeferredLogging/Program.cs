using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common;

namespace DeferredLogging
{
    class Program
    {
        private static readonly ILogger Log = LogManager.GetLogger<Program>();
        
        static void Main(string[] args)
        {
            Log.Debug(() => String.Format("Expensive value is: [{0}].", ExpensiveValue));
            Log.Info("Done!");
            Console.ReadLine();
        }

        protected static int ExpensiveValue
        {
            get
            {
                Thread.Sleep(5000);
                return 1;
            }
        }
    }
}

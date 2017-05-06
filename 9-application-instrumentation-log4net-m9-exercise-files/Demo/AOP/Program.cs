using System;
using AOP;
using log4net;
using log4net.Config;

[assembly: XmlConfigurator]
[assembly: LogMethodAspect]

namespace AOP
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        static void Main()
        {
            int index = 10;
            var fibonacci = CalculateFibonacci( index );

            Log.InfoFormat( "Fibonacci index ({1}) = {0}", fibonacci, index );
            
            Console.ReadLine();
        }

        private static int CalculateFibonacci(int i)
        {
            if (i == 0 || i == 1)
            {
                return i;
            }

            return CalculateFibonacci(i - 1) + CalculateFibonacci(i - 2);
        }
    }
}

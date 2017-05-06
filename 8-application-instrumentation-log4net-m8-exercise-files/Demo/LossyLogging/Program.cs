﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace LossyLogging
{
    class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));
        static void Main(string[] args)
        {
            try
            {
                var sum = 0;
                for (int i = 10000; i >= 0; --i)
                {
                    Log.DebugFormat("evaluating [{0}]", i);
                    sum += 10000 / i;
                }
                Console.WriteLine(sum);
            }
            catch (Exception e)
            {
                Log.Error("An exception was raised", e);
            }

            Console.ReadLine();
        }
    }
}

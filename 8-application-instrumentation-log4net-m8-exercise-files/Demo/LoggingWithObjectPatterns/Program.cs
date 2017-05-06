using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace LoggingWithObjectPatterns
{
    public class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof (Program));

        public static void Main()
        {
            using (Log.Activity("Demonstrate using a logging Stream decorator"))
            {
                var stream = File.OpenRead("loremipsum.txt");
                var loggingStream = new LoggingStreamDecorator(stream);

                using (var reader = new StreamReader(loggingStream))
                {
                    reader.ReadToEnd();
                }
            }

            Console.ReadLine();
        }

    }
}

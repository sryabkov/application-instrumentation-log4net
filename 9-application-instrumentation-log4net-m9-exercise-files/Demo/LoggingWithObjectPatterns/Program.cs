using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common;

namespace LoggingWithObjectPatterns
{
    public class Program
    {
        private static readonly ILogger Log = LogManager.GetLogger<Program>();

        public static void Main()
        {
            var stream = File.OpenRead("loremipsum.txt");

            var loggingStream = new LoggingStreamDecorator(Log, stream);

            using (var reader = new StreamReader(loggingStream))
            {
                reader.ReadToEnd();
            }

            Console.ReadLine();
        }

    }
}

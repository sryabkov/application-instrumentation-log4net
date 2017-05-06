using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace GenericLogManager
{
    class Program
    {
        private static readonly ILogger Log = LogManager.GetLogger<Program>();

        static void Main(string[] args)
        {
            Log.Debug("I just need to log this message.");
            Console.ReadLine();
        }
    }
}

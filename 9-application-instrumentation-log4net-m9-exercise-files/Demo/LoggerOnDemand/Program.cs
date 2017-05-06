using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace LoggerOnDemand
{
    class Program
    {
        static void Main()
        {
            var program = new Program();
            program.Run();

            Console.ReadLine();
        }

        void Run()
        {
            this.Log().Debug("Running!");
        }
    }
}

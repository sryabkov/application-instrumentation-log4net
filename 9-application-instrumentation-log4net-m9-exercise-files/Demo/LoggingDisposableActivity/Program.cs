using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common;

namespace LoggingDisposableActivity
{
    class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.Run();

            Console.ReadLine();
        }

        private void Run()
        {
            this.Log().Debug("Preparing to Run.");

            using (this.Log().Activity("Run"))
            {
                // ...
                this.Log().Debug( "We are running now.");
                // ...
            }
        }
    }
}

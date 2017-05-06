using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Config;

[assembly:XmlConfigurator]

namespace AdoDotNetAppender
{
    static class Program
    {
        private static ILog Log = LogManager.GetLogger(typeof (Program));

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Log.Debug("Application started");
            
            Application.EnableVisualStyles();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Log.Debug("Application complete");
        }
    }
}

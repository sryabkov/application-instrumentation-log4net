using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using log4net;
using log4net.Config;
using System.Diagnostics;

[assembly:XmlConfigurator]

namespace DebugAndTraceAppenders
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
            var textListener = new TextWriterTraceListener("log.txt");
            Trace.Listeners.Add(textListener);

            Log.Debug("Starting program");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            Log.Debug("Exiting program");
        }
    }
}

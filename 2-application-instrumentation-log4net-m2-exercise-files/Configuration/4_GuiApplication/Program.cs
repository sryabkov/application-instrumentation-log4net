using System;
using System.Windows.Forms;

[assembly: log4net.Config.XmlConfigurator]

namespace GuiApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));

            log.Debug("Logging is enabled");
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class LogManager : ILogManager
    {
        static LogManager()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config") );
        }

        public ILogger GetLogger(Type type)
        {
            var logger = log4net.LogManager.GetLogger(type);
            return new LoggerAdapter( logger );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Common
{
    public static class GenericLoggingExtensions
    {
        public static ILogger Log<T>(this T thing)
        {
            var log = LogManager.GetLogger<T>();
            return log;
        }
    }
}

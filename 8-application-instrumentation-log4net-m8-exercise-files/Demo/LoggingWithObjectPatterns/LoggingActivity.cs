using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace LoggingWithObjectPatterns
{
    public class LoggingActivity : IDisposable
    {
        private readonly ILog _log;
        private readonly string _activityName;
        private readonly IDisposable _scope;

        public LoggingActivity( ILog log, string activityName )
        {
            _log = log;
            _activityName = activityName;
            log.DebugFormat(">> Entering activity [{0}]", activityName);
            _scope = ThreadContext.Stacks["activity"].Push(activityName);
        }

        public void Dispose()
        {
            _log.DebugFormat("<< Leaving activity [{0}]", _activityName);
            _scope.Dispose();
        }
    }

    public static class LogExtensions
    {
        public static IDisposable Activity(this ILog log, string format, params object[] args)
        {
            return new LoggingActivity( log, String.Format(format,args));
        }
    }
}

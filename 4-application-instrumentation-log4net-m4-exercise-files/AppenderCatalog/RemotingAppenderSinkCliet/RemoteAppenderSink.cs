using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net.Appender;
using log4net.Core;

namespace RemotingAppenderSink
{
    public class RemoteAppenderSink : MarshalByRefObject, RemotingAppender.IRemoteLoggingSink
    {
        public class LoggingSinkEventArgs : EventArgs
        {
            public IEnumerable<LoggingEvent> LoggingEvents;
        }

        public EventHandler<LoggingSinkEventArgs> EventsReceived;

        public void LogEvents(LoggingEvent[] events)
        {
            var ev = EventsReceived;
            if (null == ev)
            {
                return;
            }

            ev.Invoke( this, new LoggingSinkEventArgs{ LoggingEvents = events });
        }
    }
}

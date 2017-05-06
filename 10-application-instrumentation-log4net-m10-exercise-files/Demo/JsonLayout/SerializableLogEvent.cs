using System;
using log4net.Core;
using log4net.Util;

namespace JsonLayout
{
    [Serializable]
    public class SerializableLogEvent
    {
        private readonly LoggingEvent _loggingEvent;
        public string Level
        {
            get { return _loggingEvent.Level.DisplayName; }
        }

        public DateTime TimeStamp
        {
            get { return _loggingEvent.TimeStamp; }
        }

        public string LoggerName
        {
            get { return _loggingEvent.LoggerName; }
        }

        public LocationInfo LocationInformation
        {
            get { return _loggingEvent.LocationInformation; }
        }

        public object MessageObject
        {
            get { return _loggingEvent.MessageObject; }
        }

        public string ExceptionObject
        {
            get
            {
                if (null == _loggingEvent.ExceptionObject)
                {
                    return null;
                }

                return _loggingEvent.ExceptionObject.ToString();
            }
        }

        public string RenderedMessage
        {
            get { return _loggingEvent.RenderedMessage; }
        }

        public string ThreadName
        {
            get { return _loggingEvent.ThreadName; }
        }

        public string UserName
        {
            get { return _loggingEvent.UserName; }
        }

        public string Identity
        {
            get { return _loggingEvent.Identity; }
        }

        public string Domain
        {
            get { return _loggingEvent.Domain; }
        }

        public PropertiesDictionary Properties
        {
            get { return _loggingEvent.Properties; }
        }

        public SerializableLogEvent(LoggingEvent loggingEvent)
        {
            _loggingEvent = loggingEvent;
        }
    }
}
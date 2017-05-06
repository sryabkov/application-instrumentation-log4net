using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;
using log4net.Core;
using log4net.Layout;

namespace JsonLayout
{
    public class JsonLayout : LayoutSkeleton
    {
        private JavaScriptSerializer _serializer;

        public override void ActivateOptions()
        {
            _serializer = new JavaScriptSerializer();
        }

        public override void Format(TextWriter writer, LoggingEvent loggingEvent)
        {
            var logEvent = new SerializableLogEvent(loggingEvent);
            
            var json = _serializer.Serialize(logEvent);
            writer.WriteLine(json);
        }
    }
}

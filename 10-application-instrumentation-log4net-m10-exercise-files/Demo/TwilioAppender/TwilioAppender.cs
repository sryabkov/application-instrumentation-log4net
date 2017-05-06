using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Twilio;
using log4net.Appender;
using log4net.Core;

namespace TwilioAppender
{
    public class TwilioAppender : AppenderSkeleton
    {
        TwilioRestClient _twilio;

        public string AccountSid { get; set; }
        public string AuthToken { get; set;  }
        public string From { get; set; }
        public string To { get; set; }
                
        public override void ActivateOptions()
        {
            _twilio = new TwilioRestClient(AccountSid, AuthToken);
            
            base.ActivateOptions();
        }
        protected override void Append(LoggingEvent loggingEvent)
        {
            var message = this.RenderLoggingEvent(loggingEvent);

            _twilio.SendSmsMessage(From, To, message);
        }
    }

    public class BufferingTwilioAppender : BufferingAppenderSkeleton
    {
        TwilioRestClient _twilio;

        public string AccountSid { get; set; }
        public string AuthToken { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public override void ActivateOptions()
        {
            _twilio = new TwilioRestClient(AccountSid, AuthToken);

            base.ActivateOptions();
        }
        protected override void SendBuffer(LoggingEvent[] loggingEvents)
        {
            foreach (var logEvent in loggingEvents)
            {
                var message = this.RenderLoggingEvent(logEvent);

                _twilio.SendSmsMessage(From, To, message);
            }
        }
    }
}

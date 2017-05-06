using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using log4net.Appender;
using log4net.Core;

namespace UdpAppenderListener
{
    public class UdpListener 
    {
        public class LoggingSinkEventArgs : EventArgs
        {
            public string Message;
        }

        public EventHandler<LoggingSinkEventArgs> LogMessageReceived;

        public void RaiseLogMessageReceivedEvent(string logMessage)
        {
            var ev = LogMessageReceived;
            if (null == ev)
            {
                return;
            }

            ev.Invoke( this, new LoggingSinkEventArgs{ Message = logMessage });
        }

        public void Start()
        {
            ThreadPool.QueueUserWorkItem(Run);
        }

        void Run(object ctx)
        {
            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Any, 8088);

            try
            {
                var udpClient = new UdpClient(8088);
                while (true)
                {
                    var buffer = udpClient.Receive(ref remoteEndPoint);
                    var message = System.Text.Encoding.ASCII.GetString(buffer);
                    RaiseLogMessageReceivedEvent( message );
                }
            }
            catch (Exception)
            {
            }
        }
    }
}

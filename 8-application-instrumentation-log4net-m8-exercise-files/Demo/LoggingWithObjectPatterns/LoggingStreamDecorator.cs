using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;

namespace LoggingWithObjectPatterns
{
    public class LoggingStreamDecorator : Stream
    {
        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof (LoggingStreamDecorator));

        private readonly Stream _baseStream;

        public LoggingStreamDecorator( Stream baseStream )
        {
            _baseStream = baseStream;
        }

        public override void Close()
        {
            using (Log.Activity("Close"))
            {
                _baseStream.Close();
            }
        }

        public override void Flush()
        {
            using (Log.Activity("Flush"))
            {
                _baseStream.Flush();
            }
        }

        public override IAsyncResult BeginRead(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            using (Log.Activity("BeginRead"))
            {
                return _baseStream.BeginRead(buffer, offset, count, callback, state);
            }
        }

        public override int EndRead(IAsyncResult asyncResult)
        {
            using (Log.Activity("EndRead"))
            {
                return _baseStream.EndRead(asyncResult);
            }
        }

        public override IAsyncResult BeginWrite(byte[] buffer, int offset, int count, AsyncCallback callback, object state)
        {
            using (Log.Activity("BeginWrite"))
            {
                return _baseStream.BeginWrite(buffer, offset, count, callback, state);
            }
        }

        public override void EndWrite(IAsyncResult asyncResult)
        {
            using (Log.Activity("EndWrite"))
            {
                _baseStream.EndWrite(asyncResult);
            }
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            using (Log.Activity("Seek"))
            {
                return _baseStream.Seek(offset, origin);
            }
        }

        public override void SetLength(long value)
        {
            using (Log.Activity("SetLength"))
            {
                _baseStream.SetLength(value);
            }
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            using (Log.Activity("Read [{0}] bytes from position [{1}]", count, Position))
            {
                return _baseStream.Read(buffer, offset, count);
            }
        }

        public override int ReadByte()
        {
            using (Log.Activity("ReadByte"))
            {
                return _baseStream.ReadByte();
            }
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            using (Log.Activity("Write [{0}] bytes at Position [{1}]", count, Position))
            {
                _baseStream.Write(buffer, offset, count);
            }
        }

        public override void WriteByte(byte value)
        {
            using (Log.Activity("WriteByte"))
            {
                _baseStream.WriteByte(value);
            }
        }

        public override bool CanRead
        {
            get { return _baseStream.CanRead; }
        }

        public override bool CanSeek
        {
            get { return _baseStream.CanSeek; }
        }

        public override bool CanTimeout
        {
            get { return _baseStream.CanTimeout; }
        }

        public override bool CanWrite
        {
            get { return _baseStream.CanWrite; }
        }

        public override long Length
        {
            get { return _baseStream.Length; }
        }

        public override long Position
        {
            get { return _baseStream.Position; }
            set { _baseStream.Position = value; }
        }

        public override int ReadTimeout
        {
            get { return _baseStream.ReadTimeout; }
            set { _baseStream.ReadTimeout = value; }
        }

        public override int WriteTimeout
        {
            get { return _baseStream.WriteTimeout; }
            set { _baseStream.WriteTimeout = value; }
        }

        public override object InitializeLifetimeService()
        {
            return _baseStream.InitializeLifetimeService();
        }

        public override ObjRef CreateObjRef(Type requestedType)
        {
            return _baseStream.CreateObjRef(requestedType);
        }

    }
}

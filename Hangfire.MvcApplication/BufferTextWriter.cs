using System;
using System.IO;
using System.Text;

namespace Hangfire.MvcApplication
{
    public class BufferTextWriter : TextWriter
    {
        private readonly StringBuilder _buffer = new StringBuilder();

        public override Encoding Encoding
        {
            get { return Encoding.Unicode; }
        }

        public override void Write(Char value)
        {
            lock (_buffer)
            {
                _buffer.Append(value);
            }
        }

        public override string ToString()
        {
            lock (_buffer)
            {
                return _buffer.ToString();
            }
        }
    }
}
using System;
using Hangfire.Logging;

namespace Hangfire.MvcApplication
{
    public class TextBufferLogProvider : ILogProvider
    {
        public ILog GetLogger(string name)
        {
            return new TextBufferLog();
        }

        public class TextBufferLog : ILog
        {
            public bool Log(LogLevel logLevel, Func<string> messageFunc)
            {
                if (messageFunc == null)
                {
                    return logLevel >= LogLevel.Info;
                }

                TextBuffer.WriteLine(messageFunc());
                return true;
            }

            public void Log<TException>(LogLevel logLevel, Func<string> messageFunc, TException exception) where TException : Exception
            {
                TextBuffer.WriteLine(messageFunc() + Environment.NewLine + exception);
            }
        }
    }
}
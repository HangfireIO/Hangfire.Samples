using System;

namespace Hangfire.ConsoleApplication
{
    public static class ConsoleServices
    {
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string format, params object[] arg)
        {
            Console.Write(DateTime.Now);
            Console.Write(' ');
            Console.WriteLine(format, arg);
        }
    }
}

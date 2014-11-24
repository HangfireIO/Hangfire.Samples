using System;

namespace Hangfire.WindowsServiceApplication
{
    public static class ConsoleServices
    {
        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string format, params object[] arg)
        {
            Console.WriteLine(format, arg);
        }
    }
}

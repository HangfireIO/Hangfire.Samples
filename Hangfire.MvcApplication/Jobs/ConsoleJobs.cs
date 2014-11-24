using System;

namespace Hangfire.MvcApplication.Jobs
{
    public class ConsoleJobs
    {
        public static void WriteHello(string name)
        {
            Console.WriteLine("{0} Hello, {1}!", DateTime.Now, name);
        }
    }
}
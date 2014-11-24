using System;
using System.IO;
using Common.Logging;
using Common.Logging.Simple;
using Microsoft.Owin.Hosting;

namespace Hangfire.ConsoleApplication
{
    class Program
    {
        static void Main()
        {
            // Configure AppDomain parameter to simplify the config – http://stackoverflow.com/a/3501950/1317575
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"));

            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter(LogLevel.Info, true, false, false, "");

            const string endpoint = "http://localhost:12345";

            using (WebApp.Start<Startup>(endpoint))
            {
                ConsoleServices.WriteLine();
                ConsoleServices.WriteLine("Hangfire Server started.");
                ConsoleServices.WriteLine("Dashboard is available at {0}/hangfire", endpoint);
                ConsoleServices.WriteLine();
                ConsoleServices.WriteLine("Type JOB to add a background job.");
                ConsoleServices.WriteLine("Press ENTER to exit...");

                string command;
                while ((command = Console.ReadLine()) != String.Empty)
                {
                    if ("job".Equals(command, StringComparison.OrdinalIgnoreCase))
                    {
                        BackgroundJob.Enqueue(() => ConsoleServices.WriteLine("Background job completed!"));
                    }
                }
            }
        }
    }
}

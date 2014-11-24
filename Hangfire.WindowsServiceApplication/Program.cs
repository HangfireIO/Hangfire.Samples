using System;
using System.IO;
using Common.Logging;
using Common.Logging.Simple;
using Microsoft.Owin.Hosting;
using Topshelf;

namespace Hangfire.WindowsServiceApplication
{
    class Program
    {
        private const string Endpoint = "http://localhost:12346";

        static void Main()
        {
            // Configure AppDomain parameter to simplify the config – http://stackoverflow.com/a/3501950/1317575
            AppDomain.CurrentDomain.SetData("DataDirectory", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "App_Data"));

            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter(LogLevel.Info, true, false, false, "");

            HostFactory.Run(x =>
            {
                x.Service<Application>(s =>
                {
                    s.ConstructUsing(name => new Application());
                    s.WhenStarted(tc => tc.Start());
                    s.WhenStopped(tc => tc.Stop());
                });
                x.RunAsLocalSystem();

                x.SetDescription("Hangfire Windows Service Sample");
                x.SetDisplayName("Hangfire Windows Service Sample");
                x.SetServiceName("Hangfire Windows Service Sample");
            });          
        }

        private class Application
        {
            private IDisposable _host;

            public void Start()
            {
                _host = WebApp.Start<Startup>(Endpoint);

                ConsoleServices.WriteLine();
                ConsoleServices.WriteLine("Hangfire Server started.");
                ConsoleServices.WriteLine("Dashboard is available at {0}/hangfire", Endpoint);
                ConsoleServices.WriteLine();
                ConsoleServices.WriteLine("Type JOB to add a background job.");
                ConsoleServices.WriteLine("Press ENTER to exit...");
            }

            public void Stop()
            {
                _host.Dispose();
            }
        }
    }
}

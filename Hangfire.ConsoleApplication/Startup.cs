using System;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.ConsoleApplication.Startup))]

namespace Hangfire.ConsoleApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseErrorPage();
            app.UseWelcomePage("/");

            app.UseHangfire(config =>
            {
                var options = new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) };
                config.UseSqlServerStorage("DefaultConnection", options);
                config.UseServer();
            });

            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("{0} Recurring job completed successfully!", DateTime.Now.ToString()), 
                Cron.Minutely);
        }
    }
}

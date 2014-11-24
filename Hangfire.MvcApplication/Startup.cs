using System;
using Hangfire.MvcApplication.Jobs;
using Hangfire.SqlServer;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Hangfire.MvcApplication.Startup))]

namespace Hangfire.MvcApplication
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfire(config =>
            {
                var options = new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) };
                config.UseSqlServerStorage("DefaultConnection", options);
                config.UseServer();
            });

            RecurringJob.AddOrUpdate(() => ConsoleJobs.WriteHello("Recurring Job"), Cron.Minutely);
        }
    }
}

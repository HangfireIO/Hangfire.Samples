using System;
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

            RecurringJob.AddOrUpdate(
                () => TextBuffer.WriteLine("Recurring Job completed successfully!"), 
                Cron.Minutely);
        }
    }
}

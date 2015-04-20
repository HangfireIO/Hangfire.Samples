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
            GlobalConfiguration.Configuration.UseSqlServerStorage(
                "DefaultConnection",
                new SqlServerStorageOptions { QueuePollInterval = TimeSpan.FromSeconds(1) });

            app.UseHangfireDashboard();
            app.UseHangfireServer();
            
            RecurringJob.AddOrUpdate(
                () => TextBuffer.WriteLine("Recurring Job completed successfully!"), 
                Cron.Minutely);
        }
    }
}

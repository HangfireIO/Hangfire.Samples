using System;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hangfire.WebFormsApplication.Startup))]
namespace Hangfire.WebFormsApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);

            GlobalConfiguration.Configuration.UseSqlServerStorage("DefaultConnection");

            app.UseHangfireDashboard();
            app.UseHangfireServer();

            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("{0} Recurring job completed successfully!", DateTime.Now.ToString()),
                Cron.Minutely);
        }
    }
}

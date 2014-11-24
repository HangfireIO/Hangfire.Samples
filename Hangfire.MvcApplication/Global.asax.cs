using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Common.Logging;
using Common.Logging.Simple;

namespace Hangfire.MvcApplication
{
    public class MvcApplication : HttpApplication
    {
        public static BufferTextWriter ConsoleOut { get; private set; }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            ConsoleOut = new BufferTextWriter();
            Console.SetOut(ConsoleOut);

            LogManager.Adapter = new ConsoleOutLoggerFactoryAdapter(LogLevel.Info, true, false, false, "");
            Console.WriteLine("{0} Application started.", DateTime.Now);
        }
    }
}

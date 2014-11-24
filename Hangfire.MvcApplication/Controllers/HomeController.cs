using System;
using System.Web.Mvc;

namespace Hangfire.MvcApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View((object)MvcApplication.ConsoleOut.ToString());
        }

        public ActionResult Buffer()
        {
            return Content(MvcApplication.ConsoleOut.ToString());
        }

        [HttpPost]
        public ActionResult Create()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("{0} Background Job completed successfully!", DateTime.Now.ToString()));

            return RedirectToAction("Index");
        }
    }
}
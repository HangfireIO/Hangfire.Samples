using System.Web.Mvc;
using Hangfire.MvcApplication.Jobs;

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
            BackgroundJob.Enqueue(() => ConsoleJobs.WriteHello("Background Job"));

            return RedirectToAction("Index");
        }
    }
}
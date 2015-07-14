using System.Linq;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class DashboardsController : Controller
    {
        private ColoradoDashboardsContext db = new ColoradoDashboardsContext();

        // GET: Dashboards
        public ActionResult Index()
        {
            return View(db.Dashboards.ToList());
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

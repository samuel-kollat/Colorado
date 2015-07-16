using System.Linq;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class HttpAnalyzerDatasController : Controller
    {
        private ColoradoDashboardsContext db = new ColoradoDashboardsContext();

        // GET: HttpAnalyzerDatas
        public ActionResult Index()
        {
            return View(db.HttpAnalyzerDatas.ToList());
        }

        public ActionResult Chart()
        {
            return View();
        }

        public JsonResult ChartDataJsonResult()
        {
            var data = db.HttpAnalyzerDatas
                .GroupBy(d => d.DestinationIp)
                .Select(group => new
                {
                    Destination = group.Key,
                    Amount = group.Sum(g => g.Quantity)
                });

            return Json(data.ToList(), JsonRequestBehavior.AllowGet);
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

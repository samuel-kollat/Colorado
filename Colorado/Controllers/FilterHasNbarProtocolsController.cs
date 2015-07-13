using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class FilterHasNbarProtocolsController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: FilterHasNbarProtocols
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filterHasNbarProtocols = db.FilterHasNbarProtocols.Where(f => f.filter_id == id).Include(f => f.Filter).Include(f => f.NbarProtocol);
            ViewBag.filter_id = id;
            return View(filterHasNbarProtocols.ToList());
        }

        // GET: FilterHasNbarProtocols/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var filter = db.Filters.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }

            ViewBag.filterName = filter.name;
            ViewBag.filter_id = id;
            ViewBag.nbar_protocol_id = new SelectList(db.NbarProtocols, "id", "protocol_name");
            return View();
        }

        // POST: FilterHasNbarProtocols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "filter_id,nbar_protocol_id")] FilterHasNbarProtocol filterHasNbarProtocol)
        {
            if (ModelState.IsValid)
            {
                db.FilterHasNbarProtocols.Add(filterHasNbarProtocol);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = filterHasNbarProtocol.filter_id });
            }

            ViewBag.filter_id = new SelectList(db.Filters, "id", "name", filterHasNbarProtocol.filter_id);
            ViewBag.nbar_protocol_id = new SelectList(db.NbarProtocols, "id", "protocol_name", filterHasNbarProtocol.nbar_protocol_id);
            return View(filterHasNbarProtocol);
        }

        // GET: FilterHasNbarProtocols/Delete/5
        public ActionResult Delete(int? filterId, int? nbarId)
        {
            if (filterId == null || nbarId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FilterHasNbarProtocol filterHasNbarProtocol = db.FilterHasNbarProtocols.First(f => (f.filter_id == filterId && f.nbar_protocol_id == nbarId));
            if (filterHasNbarProtocol == null)
            {
                return HttpNotFound();
            }
            return View(filterHasNbarProtocol);
        }

        // POST: FilterHasNbarProtocols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? filterId, int? nbarId)
        {
            FilterHasNbarProtocol filterHasNbarProtocol = db.FilterHasNbarProtocols.First(f => (f.filter_id == filterId && f.nbar_protocol_id == nbarId));
            db.FilterHasNbarProtocols.Remove(filterHasNbarProtocol);
            db.SaveChanges();
            return RedirectToAction("Index", new {id = filterId});
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

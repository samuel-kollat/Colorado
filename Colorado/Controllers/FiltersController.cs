using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;
using Filter = System.Web.Mvc.Filter;

namespace Colorado.Controllers
{
    public class FiltersController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: Filters
        public ActionResult Index()
        {
            var filters = db.Filters.Include(f => f.Application).Include(f => f.NbarProtocols);
            return View(filters.ToList());
        }

        // GET: Filters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colorado.Models.Filter filter = db.Filters.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            return View(filter);
        }

        // GET: Filters/Create
        public ActionResult Create()
        {
            ViewBag.application_id = new SelectList(db.Applications, "id", "name");
            return View();
        }

        // POST: Filters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,type,application_id")] Colorado.Models.Filter filter)
        {
            if (ModelState.IsValid)
            {
                db.Filters.Add(filter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.application_id = new SelectList(db.Applications, "id", "name", filter.application_id);
            return View(filter);
        }

        // GET: Filters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colorado.Models.Filter filter = db.Filters.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            ViewBag.application_id = new SelectList(db.Applications, "id", "name", filter.application_id);
            return View(filter);
        }

        // POST: Filters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,type,application_id")] Colorado.Models.Filter filter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(filter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.application_id = new SelectList(db.Applications, "id", "name", filter.application_id);
            return View(filter);
        }

        // GET: Filters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Colorado.Models.Filter filter = db.Filters.Find(id);
            if (filter == null)
            {
                return HttpNotFound();
            }
            return View(filter);
        }

        // POST: Filters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Colorado.Models.Filter filter = db.Filters.Find(id);
            db.Filters.Remove(filter);
            db.SaveChanges();
            return RedirectToAction("Index");
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

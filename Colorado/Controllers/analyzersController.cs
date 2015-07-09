using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class AnalyzersController : Controller
    {
        private readonly ColoradoContext _db = new ColoradoContext();

        // GET: analyzers
        public ActionResult Index()
        {
            return View(_db.Analyzers.ToList());
        }

        // GET: analyzers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analyzer analyzer = _db.Analyzers.Find(id);
            if (analyzer == null)
            {
                return HttpNotFound();
            }
            return View(analyzer);
        }

        // GET: analyzers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: analyzers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,name,description,src,args")] Analyzer analyzer)
        {
            if (ModelState.IsValid)
            {
                _db.Analyzers.Add(analyzer);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(analyzer);
        }

        // GET: analyzers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analyzer analyzer = _db.Analyzers.Find(id);
            if (analyzer == null)
            {
                return HttpNotFound();
            }
            return View(analyzer);
        }

        // POST: analyzers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,name,description,src,args")] Analyzer analyzer)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(analyzer).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(analyzer);
        }

        // GET: analyzers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Analyzer analyzer = _db.Analyzers.Find(id);
            if (analyzer == null)
            {
                return HttpNotFound();
            }
            return View(analyzer);
        }

        // POST: analyzers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Analyzer analyzer = _db.Analyzers.Find(id);
            _db.Analyzers.Remove(analyzer);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class NbarProtocolsController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: NbarProtocols
        public ActionResult Index()
        {
            return View(db.NbarProtocols.ToList());
        }

        // GET: NbarProtocols/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NbarProtocol nbarProtocol = db.NbarProtocols.Find(id);
            if (nbarProtocol == null)
            {
                return HttpNotFound();
            }
            return View(nbarProtocol);
        }

        // GET: NbarProtocols/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NbarProtocols/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,protocol_name,protocol_description,protocol_id")] NbarProtocol nbarProtocol)
        {
            if (ModelState.IsValid)
            {
                db.NbarProtocols.Add(nbarProtocol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nbarProtocol);
        }

        // GET: NbarProtocols/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NbarProtocol nbarProtocol = db.NbarProtocols.Find(id);
            if (nbarProtocol == null)
            {
                return HttpNotFound();
            }
            return View(nbarProtocol);
        }

        // POST: NbarProtocols/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,protocol_name,protocol_description,protocol_id")] NbarProtocol nbarProtocol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nbarProtocol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nbarProtocol);
        }

        // GET: NbarProtocols/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NbarProtocol nbarProtocol = db.NbarProtocols.Find(id);
            if (nbarProtocol == null)
            {
                return HttpNotFound();
            }
            return View(nbarProtocol);
        }

        // POST: NbarProtocols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NbarProtocol nbarProtocol = db.NbarProtocols.Find(id);
            db.NbarProtocols.Remove(nbarProtocol);
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

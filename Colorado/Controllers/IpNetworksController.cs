using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class IpNetworksController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: IpNetworks
        public ActionResult Index()
        {
            return View(db.IpNetworks.ToList());
        }

        // GET: IpNetworks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpNetwork ipNetwork = db.IpNetworks.Find(id);
            if (ipNetwork == null)
            {
                return HttpNotFound();
            }
            return View(ipNetwork);
        }

        // GET: IpNetworks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IpNetworks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,address,mask")] IpNetwork ipNetwork)
        {
            if (ModelState.IsValid)
            {
                db.IpNetworks.Add(ipNetwork);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ipNetwork);
        }

        // GET: IpNetworks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpNetwork ipNetwork = db.IpNetworks.Find(id);
            if (ipNetwork == null)
            {
                return HttpNotFound();
            }
            return View(ipNetwork);
        }

        // POST: IpNetworks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,address,mask")] IpNetwork ipNetwork)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ipNetwork).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ipNetwork);
        }

        // GET: IpNetworks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IpNetwork ipNetwork = db.IpNetworks.Find(id);
            if (ipNetwork == null)
            {
                return HttpNotFound();
            }
            return View(ipNetwork);
        }

        // POST: IpNetworks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IpNetwork ipNetwork = db.IpNetworks.Find(id);
            db.IpNetworks.Remove(ipNetwork);
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

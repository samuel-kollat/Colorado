using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class AccessListsController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: AccessLists
        public ActionResult Index()
        {
            var accessLists = db.AccessLists.Include(a => a.Filter).Include(a => a.IpDestination).Include(a => a.IpSource).Include(a => a.PortDestination).Include(a => a.PortSource);
            return View(accessLists.ToList());
        }

        // GET: AccessLists/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessList accessList = db.AccessLists.Find(id);
            if (accessList == null)
            {
                return HttpNotFound();
            }
            return View(accessList);
        }

        // GET: AccessLists/Create
        public ActionResult Create()
        {
            ViewBag.filter_id = new SelectList(db.Filters, "id", "name");
            ViewBag.ip_destination = new SelectList(db.IpNetworks, "id", "address");
            ViewBag.ip_source = new SelectList(db.IpNetworks, "id", "address");
            ViewBag.pn_destination = new SelectList(db.Ports, "id", "id");
            ViewBag.pn_source = new SelectList(db.Ports, "id", "id");
            return View();
        }

        // POST: AccessLists/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,number,action,protocol,ttl,ip_source,ip_destination,pn_source,pn_destination,filter_id")] AccessList accessList)
        {
            if (ModelState.IsValid)
            {
                db.AccessLists.Add(accessList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.filter_id = new SelectList(db.Filters, "id", "name", accessList.filter_id);
            ViewBag.ip_destination = new SelectList(db.IpNetworks, "id", "address", accessList.ip_destination);
            ViewBag.ip_source = new SelectList(db.IpNetworks, "id", "address", accessList.ip_source);
            ViewBag.pn_destination = new SelectList(db.Ports, "id", "id", accessList.pn_destination);
            ViewBag.pn_source = new SelectList(db.Ports, "id", "id", accessList.pn_source);
            return View(accessList);
        }

        // GET: AccessLists/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessList accessList = db.AccessLists.Find(id);
            if (accessList == null)
            {
                return HttpNotFound();
            }
            ViewBag.filter_id = new SelectList(db.Filters, "id", "name", accessList.filter_id);
            ViewBag.ip_destination = new SelectList(db.IpNetworks, "id", "address", accessList.ip_destination);
            ViewBag.ip_source = new SelectList(db.IpNetworks, "id", "address", accessList.ip_source);
            ViewBag.pn_destination = new SelectList(db.Ports, "id", "id", accessList.pn_destination);
            ViewBag.pn_source = new SelectList(db.Ports, "id", "id", accessList.pn_source);
            return View(accessList);
        }

        // POST: AccessLists/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,number,action,protocol,ttl,ip_source,ip_destination,pn_source,pn_destination,filter_id")] AccessList accessList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accessList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.filter_id = new SelectList(db.Filters, "id", "name", accessList.filter_id);
            ViewBag.ip_destination = new SelectList(db.IpNetworks, "id", "address", accessList.ip_destination);
            ViewBag.ip_source = new SelectList(db.IpNetworks, "id", "address", accessList.ip_source);
            ViewBag.pn_destination = new SelectList(db.Ports, "id", "id", accessList.pn_destination);
            ViewBag.pn_source = new SelectList(db.Ports, "id", "id", accessList.pn_source);
            return View(accessList);
        }

        // GET: AccessLists/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AccessList accessList = db.AccessLists.Find(id);
            if (accessList == null)
            {
                return HttpNotFound();
            }
            return View(accessList);
        }

        // POST: AccessLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccessList accessList = db.AccessLists.Find(id);
            db.AccessLists.Remove(accessList);
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

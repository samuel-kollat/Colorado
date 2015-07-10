using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Colorado.Models;

namespace Colorado.Controllers
{
    public class RoutersController : Controller
    {
        private ColoradoContext db = new ColoradoContext();

        // GET: Routers
        public ActionResult Index()
        {
            var routers = db.Routers.Include(r => r.Application);
            return View(routers.ToList());
        }

        // GET: Routers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            return View(router);
        }

        // GET: Routers/Create
        public ActionResult Create()
        {
            ViewBag.application_id = new SelectList(db.Applications, "id", "name");
            return View();
        }

        // POST: Routers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,management_ip,name,username,password,interfaces,application_id")] Router router)
        {
            if (ModelState.IsValid)
            {
                db.Routers.Add(router);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.application_id = new SelectList(db.Applications, "id", "name", router.application_id);
            return View(router);
        }

        // GET: Routers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            ViewBag.application_id = new SelectList(db.Applications, "id", "name", router.application_id);
            return View(router);
        }

        // POST: Routers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,management_ip,name,username,password,interfaces,application_id")] Router router)
        {
            if (ModelState.IsValid)
            {
                db.Entry(router).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.application_id = new SelectList(db.Applications, "id", "name", router.application_id);
            return View(router);
        }

        // GET: Routers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Router router = db.Routers.Find(id);
            if (router == null)
            {
                return HttpNotFound();
            }
            return View(router);
        }

        // POST: Routers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Router router = db.Routers.Find(id);
            db.Routers.Remove(router);
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

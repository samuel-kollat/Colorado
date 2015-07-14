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
    public class DnsTrackedDomainsController : Controller
    {
        private ColoradoDashboardsContext db = new ColoradoDashboardsContext();

        // GET: DnsTrackedDomains
        public ActionResult Index()
        {
            return View(db.DnsTrackedDomains.ToList());
        }

        // GET: DnsTrackedDomains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnsTrackedDomain dnsTrackedDomain = db.DnsTrackedDomains.Find(id);
            if (dnsTrackedDomain == null)
            {
                return HttpNotFound();
            }
            return View(dnsTrackedDomain);
        }

        // GET: DnsTrackedDomains/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DnsTrackedDomains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DomainExpression,DomainStatus")] DnsTrackedDomain dnsTrackedDomain)
        {
            if (ModelState.IsValid)
            {
                db.DnsTrackedDomains.Add(dnsTrackedDomain);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dnsTrackedDomain);
        }

        // GET: DnsTrackedDomains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnsTrackedDomain dnsTrackedDomain = db.DnsTrackedDomains.Find(id);
            if (dnsTrackedDomain == null)
            {
                return HttpNotFound();
            }
            return View(dnsTrackedDomain);
        }

        // POST: DnsTrackedDomains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DomainExpression,DomainStatus")] DnsTrackedDomain dnsTrackedDomain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dnsTrackedDomain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dnsTrackedDomain);
        }

        // GET: DnsTrackedDomains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DnsTrackedDomain dnsTrackedDomain = db.DnsTrackedDomains.Find(id);
            if (dnsTrackedDomain == null)
            {
                return HttpNotFound();
            }
            return View(dnsTrackedDomain);
        }

        // POST: DnsTrackedDomains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DnsTrackedDomain dnsTrackedDomain = db.DnsTrackedDomains.Find(id);
            db.DnsTrackedDomains.Remove(dnsTrackedDomain);
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

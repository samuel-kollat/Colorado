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
    public class DnsAnalyzerDatasController : Controller
    {
        private ColoradoDashboardsContext db = new ColoradoDashboardsContext();

        // GET: DnsAnalyzerDatas
        public ActionResult Index()
        {
            var model = db.DnsAnalyzerDatas.Include(d => d.ResponseAddresses);
            return View(model.ToList());
        }
    }
}

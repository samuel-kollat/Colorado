using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Colorado.Models;
using Colorado.ViewModels;

namespace Colorado.Controllers
{
    public class DnsAnalyzerDatasController : Controller
    {
        private ColoradoDashboardsContext db = new ColoradoDashboardsContext();

        // GET: DnsAnalyzerDatas
        public ActionResult Index()
        {
            var model = db.DnsAnalyzerDatas.Include(d => d.ResponseAddresses).ToList();
            var tracked = db.DnsTrackedDomains.ToList();

            foreach (var track in tracked)
            {
                track.DomainExpression = track.DomainExpression.Replace(".", "\\.").Replace("*", ".*") + "$";
            }

            ICollection<DnsLookUp> lookUps = new List<DnsLookUp>();

            foreach (var lookup in model)
            {
                DnsTrackedDomain.Status? status = null;
                string cssBgCollor = "";

                foreach (var track in tracked)
                {
                    if (Regex.IsMatch(lookup.DomainName, track.DomainExpression))
                    {
                        status = track.DomainStatus;

                        switch (track.DomainStatus)
                        {
                            case DnsTrackedDomain.Status.Success:
                                cssBgCollor = "aquamarine";
                                break;
                            case DnsTrackedDomain.Status.Info:
                                cssBgCollor = "aqua";
                                break;
                            case DnsTrackedDomain.Status.Warning:
                                cssBgCollor = "bisque";
                                break;
                            case DnsTrackedDomain.Status.Error:
                                cssBgCollor = "lightcoral";
                                break;
                        }
                        break;
                    }
                }

                lookUps.Add(new DnsLookUp { Data = lookup, Status = status, CssBgCollor = cssBgCollor });
            }

            return View(lookUps);
        }
    }
}

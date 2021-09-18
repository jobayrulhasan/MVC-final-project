using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalPorjectDatabaseFirst3.Models;
using PagedList;

namespace FinalPorjectDatabaseFirst3.Controllers
{
    public class BusesController : Controller
    {
        private TicketBookingSystemEntities db = new TicketBookingSystemEntities();

        // GET: Buses
        //This section is for pagination
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            if (searchString != null)
            {
                page = 1;

            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;

            var bus = from s in db.Buses
                        select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                bus = bus.Where(s =>
               s.BusName.ToUpper().Contains(searchString.ToUpper())
                ||
               s.BusName.ToUpper().Contains(searchString.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    bus = bus.OrderByDescending(s => s.BusName);
                    break;
                default:
                    bus = bus.OrderBy(s => s.BusName);
                    break;
            }
            int pageSize = 3;
            int pageNumber = (page ?? 1);
            return View(bus.ToPagedList(pageNumber, pageSize));

            //return View(db.Buses.ToList());
        }

        // GET: Buses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // GET: Buses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Buses/Create
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BusId,BusName,BusType,NoOfSeat,LicenseNo,FitnessStatus")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                var busid = db.Buses.Max(o => (int?)o.BusId) ?? 0;
                var otbBus = new Bus();
                otbBus.BusId = busid + 1;
                otbBus.BusName = bus.BusName;
                otbBus.BusType = bus.BusType;
                otbBus.NoOfSeat = bus.NoOfSeat;
                otbBus.LicenseNo = bus.LicenseNo;
                otbBus.FitnessStatus = bus.FitnessStatus;
                db.Buses.Add(bus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bus);
        }

        // GET: Buses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Buses/Edit/5
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BusId,BusName,BusType,NoOfSeat,LicenseNo,FitnessStatus,ImagePath,RouteId")] Bus bus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bus);
        }

        // GET: Buses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        // POST: Buses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bus bus = db.Buses.Find(id);
            db.Buses.Remove(bus);
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

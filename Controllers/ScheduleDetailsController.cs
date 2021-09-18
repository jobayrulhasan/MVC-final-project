using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FinalPorjectDatabaseFirst3.Models;

namespace FinalPorjectDatabaseFirst3.Controllers
{
    public class ScheduleDetailsController : Controller
    {
        private TicketBookingSystemEntities db = new TicketBookingSystemEntities();

        // GET: ScheduleDetails
        public ActionResult Index()
        {
            var scheduleDetails = db.ScheduleDetails.Include(s => s.Bus).Include(s => s.Schedule);
            return View(scheduleDetails.ToList());
        }

        // GET: ScheduleDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Create
        public ActionResult Create()
        {
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus");
            return View();
        }

        // POST: ScheduleDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ScheduleDetailsId,SeatNo,BusId,ScheduleId,ScheduleStatus")] ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleDetails.Add(scheduleDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", scheduleDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", scheduleDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ScheduleDetailsId,SeatNo,BusId,ScheduleId,ScheduleStatus")] ScheduleDetail scheduleDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", scheduleDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", scheduleDetail.ScheduleId);
            return View(scheduleDetail);
        }

        // GET: ScheduleDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            if (scheduleDetail == null)
            {
                return HttpNotFound();
            }
            return View(scheduleDetail);
        }

        // POST: ScheduleDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleDetail scheduleDetail = db.ScheduleDetails.Find(id);
            db.ScheduleDetails.Remove(scheduleDetail);
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

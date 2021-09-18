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
    public class BookingDetailsController : Controller
    {
        private TicketBookingSystemEntities db = new TicketBookingSystemEntities();

        // GET: BookingDetails
        public ActionResult Index()
        {
            var bookingDetails = db.BookingDetails.Include(b => b.Booking).Include(b => b.Bus).Include(b => b.Schedule).Include(b => b.ScheduleDetail);
            return View(bookingDetails.ToList());
        }

        // GET: BookingDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetail bookingDetail = db.BookingDetails.Find(id);
            if (bookingDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetail);
        }

        // GET: BookingDetails/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "CustomerName");
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName");
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus");
            ViewBag.ScheduleDetailsId = new SelectList(db.ScheduleDetails, "ScheduleDetailsId", "SeatNo");
            return View();
        }

        // POST: BookingDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookingDetailsId,SeatNo,CustomerName,CustomerMobile,BookingId,BusId,ScheduleId,ScheduleDetailsId")] BookingDetail bookingDetail)
        {
            if (ModelState.IsValid)
            {
                db.BookingDetails.Add(bookingDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "CustomerName", bookingDetail.BookingId);
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", bookingDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", bookingDetail.ScheduleId);
            ViewBag.ScheduleDetailsId = new SelectList(db.ScheduleDetails, "ScheduleDetailsId", "SeatNo", bookingDetail.ScheduleDetailsId);
            return View(bookingDetail);
        }

        // GET: BookingDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetail bookingDetail = db.BookingDetails.Find(id);
            if (bookingDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "CustomerName", bookingDetail.BookingId);
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", bookingDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", bookingDetail.ScheduleId);
            ViewBag.ScheduleDetailsId = new SelectList(db.ScheduleDetails, "ScheduleDetailsId", "SeatNo", bookingDetail.ScheduleDetailsId);
            return View(bookingDetail);
        }

        // POST: BookingDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookingDetailsId,SeatNo,CustomerName,CustomerMobile,BookingId,BusId,ScheduleId,ScheduleDetailsId")] BookingDetail bookingDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookingDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingId = new SelectList(db.Bookings, "BookingId", "CustomerName", bookingDetail.BookingId);
            ViewBag.BusId = new SelectList(db.Buses, "BusId", "BusName", bookingDetail.BusId);
            ViewBag.ScheduleId = new SelectList(db.Schedules, "ScheduleId", "BusStatus", bookingDetail.ScheduleId);
            ViewBag.ScheduleDetailsId = new SelectList(db.ScheduleDetails, "ScheduleDetailsId", "SeatNo", bookingDetail.ScheduleDetailsId);
            return View(bookingDetail);
        }

        // GET: BookingDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingDetail bookingDetail = db.BookingDetails.Find(id);
            if (bookingDetail == null)
            {
                return HttpNotFound();
            }
            return View(bookingDetail);
        }

        // POST: BookingDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingDetail bookingDetail = db.BookingDetails.Find(id);
            db.BookingDetails.Remove(bookingDetail);
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

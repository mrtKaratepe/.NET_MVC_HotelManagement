using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement;

namespace HotelManagement.Controllers
{
    [Authorize(Roles = "user")]
    public class AddGuestController : Controller
    {
        private HotelManagementEntities db = new HotelManagementEntities();

        public ActionResult Index()
        {
            var guests = db.Guests.Include(g => g.Booking);
            return View(guests.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        public ActionResult Create()
        {
            ViewBag.BookingBookingId = new SelectList(db.Bookings, "BookingId", "BookingId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="GuestId,BookingId,Name,Surname,BDate,Phone,Gender,BookingBookingId")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Guests.Add(guest);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BookingBookingId = new SelectList(db.Bookings, "BookingId", "BookingId", guest.BookingBookingId);
            return View(guest);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            ViewBag.BookingBookingId = new SelectList(db.Bookings, "BookingId", "BookingId", guest.BookingBookingId);
            return View(guest);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="GuestId,BookingId,Name,Surname,BDate,Phone,Gender,BookingBookingId")] Guest guest)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guest).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BookingBookingId = new SelectList(db.Bookings, "BookingId", "BookingId", guest.BookingBookingId);
            return View(guest);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guest guest = db.Guests.Find(id);
            if (guest == null)
            {
                return HttpNotFound();
            }
            return View(guest);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Guest guest = db.Guests.Find(id);
            db.Guests.Remove(guest);
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

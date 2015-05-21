using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement;
using WebMatrix.WebData;

namespace HotelManagement.Controllers
{
    [Authorize(Roles = "user, admin")]
    public class BookingController : Controller
    {
        private HotelManagementEntities db = new HotelManagementEntities();

        public ActionResult Index()
        {
            var bookings = db.Bookings.Include(b => b.Room).Include(b => b.Hotel).Include(b => b.UserProfile);
            return View(bookings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        public ActionResult Create()
        {
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNumber");
            ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "HotelName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BookingId,UserId,Cost,InDate,OutDate,CustomerCount,HotelId,RoomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                booking.UserId = WebSecurity.CurrentUserId;
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "HotelName", booking.HotelId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", booking.UserId);
            return View(booking);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "HotelName", booking.HotelId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", booking.UserId);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BookingId,UserId,Cost,InDate,OutDate,CustomerCount,HotelId,RoomId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoomId = new SelectList(db.Rooms, "RoomId", "RoomNumber", booking.RoomId);
            ViewBag.HotelId = new SelectList(db.Hotels, "HotelId", "HotelName", booking.HotelId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", booking.UserId);
            return View(booking);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
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

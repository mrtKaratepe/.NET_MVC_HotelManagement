using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HotelManagement;
using HotelManagement.Models;
using WebMatrix.WebData;
using System.Web.Security;

namespace HotelManagement.Controllers
{
    [Authorize(Roles = "admin, user")]
    public class UserInformationsController : Controller
    {
        private HotelManagementEntities db = new HotelManagementEntities();

        public ActionResult Index()
        {
            var userinformations = db.UserInformations.Include(u => u.UserProfile);
            return View(userinformations.ToList());
        }

        public ActionResult Details()
        {
            UserInformation userinformation = db.UserInformations.Find(WebSecurity.CurrentUserId);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="InformationId,UserId,Name,Surname,Bday,Gender,MaritalStatus,Phone")] UserInformation userinformation)
        {
            if (ModelState.IsValid)
            {
                if (Roles.IsUserInRole("user"))
                {
                    userinformation.UserId = WebSecurity.CurrentUserId;
                }
                
                db.UserInformations.Add(userinformation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", userinformation.UserId);
            return View(userinformation);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userinformation = db.UserInformations.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", userinformation.UserId);
            return View(userinformation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="InformationId,UserId,Name,Surname,Bday,Gender,MaritalStatus,Phone")] UserInformation userinformation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userinformation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", userinformation.UserId);
            return View(userinformation);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserInformation userinformation = db.UserInformations.Find(id);
            if (userinformation == null)
            {
                return HttpNotFound();
            }
            return View(userinformation);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserInformation userinformation = db.UserInformations.Find(id);
            db.UserInformations.Remove(userinformation);
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

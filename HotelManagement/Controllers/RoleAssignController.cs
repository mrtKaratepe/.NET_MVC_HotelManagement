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
    public class RoleAssignController : Controller
    {
        private HotelManagementEntities db = new HotelManagementEntities();

        public ActionResult Index()
        {
            var webpages_usersinroles = db.webpages_UsersInRoles.Include(w => w.UserProfile).Include(w => w.UserProfile1).Include(w => w.UserProfile2).Include(w => w.webpages_Roles).Include(w => w.webpages_Roles1).Include(w => w.webpages_Roles2);
            return View(webpages_usersinroles.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_usersinroles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="UserId,RoleId")] webpages_UsersInRoles webpages_usersinroles)
        {
            if (ModelState.IsValid)
            {
                db.webpages_UsersInRoles.Add(webpages_usersinroles);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="UserId,RoleId")] webpages_UsersInRoles webpages_usersinroles)
        {
            if (ModelState.IsValid)
            {
                db.Entry(webpages_usersinroles).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.UserId = new SelectList(db.UserProfiles, "UserId", "Username", webpages_usersinroles.UserId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            ViewBag.RoleId = new SelectList(db.webpages_Roles, "RoleId", "RoleName", webpages_usersinroles.RoleId);
            return View(webpages_usersinroles);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            if (webpages_usersinroles == null)
            {
                return HttpNotFound();
            }
            return View(webpages_usersinroles);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            webpages_UsersInRoles webpages_usersinroles = db.webpages_UsersInRoles.Find(id);
            db.webpages_UsersInRoles.Remove(webpages_usersinroles);
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

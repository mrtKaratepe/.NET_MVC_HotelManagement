using HotelManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login logindata,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                if (WebSecurity.Login(logindata.Username, logindata.Password))
                {
                    if(ReturnUrl != null){
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Sorry the username is Invalid...");
                    return View(logindata);
                }   
            }
            ModelState.AddModelError("", "Sorry the username is Invalid...");
            return View(logindata);
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register registerData)
        {
            string role = "user";
            if (ModelState.IsValid)
            {
                try
                {
                    WebSecurity.CreateUserAndAccount(registerData.Username, registerData.Password, false);
                    Roles.AddUserToRole(registerData.Username,role);
                    return RedirectToAction("Index", "Home");
                }
                catch (MembershipCreateUserException exception)
                {
                    ModelState.AddModelError("", "Sorry the username is already exist...");
                    return View(registerData);
                }
            }
            ModelState.AddModelError("","Sorry the username is already exist...");
            return View(registerData);
        }

        public ActionResult Logout()
        {
            WebSecurity.Logout();
            return RedirectToAction("Index","Home");
        }

	}
}
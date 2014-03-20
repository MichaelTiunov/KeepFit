﻿using System;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Serialization;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    public class AccountController : BaseController
    {
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                //var user = context.Users.FirstOrDefault(x => x.UserName == model.UserName && x.Password == model.Password);  //UserManager.FindAsync(model.UserName, model.Password);
                //if (user != null)
                //{
                //    SetupPrincipal(user, RoleType.Admin ,"keepFit", model.RememberMe);
                //    SetRole(RoleType.Admin, model.RememberMe);
                //    RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Invalid username or password.");
                //}
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void SetRole(RoleType role, bool rememberMe = false)
        {
            var principal = HttpContext.User;

            KeepFitIdentity.SetRole(role);

            //AuthenticateUser(principal, rememberMe);
        }

        //private void SetupPrincipal(User user, RoleType role, string securityToken, bool rememberMe = false, bool isPasswordExpired = false)
        //{
        //    IPrincipal principal = new KeepFitPrincipal(user.UserId, user.UserId, user.UserName, user.UserName, user.UserName, role, securityToken, isPasswordExpired, rememberMe);

        //    AuthenticateUser(principal, rememberMe);
        //}
        //private void AuthenticateUser(IPrincipal principal, bool rememberMe = false)
        //{
        //    Thread.CurrentPrincipal = HttpContext.User = principal;

        //    // Save the principal into the Forms Authentication Ticket
        //    var userData = new StringBuilder();
        //    using (var writer = new StringWriter(userData))
        //    {
        //        var serializer = new XmlSerializer(typeof(KeepFitPrincipal));
        //        serializer.Serialize(writer, Thread.CurrentPrincipal);
        //    }

        //    var timeout = rememberMe ?
        //        DateTime.Now.AddDays(1)
        //        : DateTime.Now.AddMinutes(30);

        //    var ticket = new FormsAuthenticationTicket(
        //        1, principal.Identity.Name, DateTime.Now, timeout, rememberMe, userData.ToString());

        //    HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
        //}

        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

       
        //
        // POST: /Account/LogOff
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            if (Session != null)
            {
                Session.Abandon();
            }

            // clear authentication cookie
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, string.Empty);
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);

            FormsAuthentication.RedirectToLoginPage();
            FormsAuthentication.SignOut();

            return RedirectToAction("Login");
        }
    }
}
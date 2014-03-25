using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Xml.Serialization;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Models;

namespace KeepFit.Web.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        public AccountController(IAccountService accountService, IIdentityService identityService)
            : base(accountService, identityService)
        {
        }

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
                var user = accountService.GetUserByUserName(model.UserName);
                switch (accountService.CheckCredintials(user, model.Password))
                {
                    case CheckCredentialsResultType.NoPasswordHasBeenSetUp:
                        ModelState.AddModelError("", "NoPassword");
                        break;
                    case CheckCredentialsResultType.InvalidCredentials:
                        ModelState.AddModelError("", "Invalid");
                        break;
                    case CheckCredentialsResultType.Ok:
                        var individualRole = user.Individual.IndividualRoles.FirstOrDefault();
                        if (individualRole != null)
                        {
                            var role = (RoleType)individualRole.RoleId;
                            SetupPrincipal(user, role, "keepfit", model.RememberMe);
                            SetRole(role, model.RememberMe);
                            RedirectToAction("Index", "Home");
                        }
                        break;
                    default:
                        ModelState.AddModelError("", "Error");
                        break;
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        private void SetupPrincipal(User user, RoleType role, string securityToken, bool rememberMe = false, bool isPasswordExpired = false)
        {
            IPrincipal principal = new KeepFitPrincipal(user.IndividualId, user.IndividualId, user.Username, user.Individual.FirstName, user.Individual.LastName, role, securityToken, isPasswordExpired, rememberMe);

            AuthenticateUser(principal, rememberMe);
        }
        private void SetRole(RoleType role, bool rememberMe = false)
        {
            var principal = HttpContext.User;

            KeepFitIdentity.SetRole(role);

            //AuthenticateUser(principal, rememberMe);
        }
        private void AuthenticateUser(IPrincipal principal, bool rememberMe = false)
        {
            Thread.CurrentPrincipal = HttpContext.User = principal;

            // Save the principal into the Forms Authentication Ticket
            var userData = new StringBuilder();
            using (var writer = new StringWriter(userData))
            {
                var serializer = new XmlSerializer(typeof(KeepFitPrincipal));
                serializer.Serialize(writer, Thread.CurrentPrincipal);
            }

            var timeout = rememberMe ?
                DateTime.Now.AddDays(30)
                : DateTime.Now.AddMinutes(30);

            var ticket = new FormsAuthenticationTicket(
                1, principal.Identity.Name, DateTime.Now, timeout, rememberMe, userData.ToString());

            HttpContext.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket)));
        }


        //
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (!accountService.IsUsernameExists(model.UserName))
                {
                    accountService.CreateUser(new User
                    {
                        Username = model.UserName
                    }, model.FirstName, model.LastName, model.Password, new List<RoleType> { RoleType.User });

                    return RedirectToAction("Login");
                }

                ModelState.AddModelError("", "Don't play w/ it, plz ;-)");
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }
    }
}
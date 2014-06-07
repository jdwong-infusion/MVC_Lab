using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Lab.DAL;
using MVC_Lab.Models;

namespace MVC_Lab.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private InfusionRelayChatContext db = new InfusionRelayChatContext();

        //
        // GET: /Account/Login

        [HttpGet]
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
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (isValidLogin(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                else
                {
                    ModelState.AddModelError("", "Login data is incorrect!");
                }
            }
            return View(model);
        }

        //
        // GET: /Account/LogOff

        [HttpGet]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }

        #region Helpers
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        /// <summary>
        /// Checks if user with given password exists in the database
        /// </summary>
        /// <param name="_username">User name</param>
        /// <param name="_password">User password</param>
        /// <returns>True if user exist and password is correct</returns>
        public bool isValidLogin(string _username, string _password)
        {
            // Mock implementation for lab
            return
                db.Users.Any(
                    u =>
                    u.UserName.Equals(_username, StringComparison.InvariantCultureIgnoreCase) &&
                    u.Password.Equals(_password));
        }
        #endregion

    }
}

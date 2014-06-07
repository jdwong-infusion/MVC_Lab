using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MVC_Lab.Models;
using MVC_Lab.DAL;

namespace MVC_Lab.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private InfusionRelayChatContext db = new InfusionRelayChatContext();

        //
        // GET: /User/

        [HttpGet]
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        //
        // GET: /User/Details/5

        [HttpGet]
        public ActionResult Details(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // GET: /User/Create

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.UserName.Equals(user.UserName, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ModelState.AddModelError("UserName", "The user name you have selected is already in use.");
                    return View(user);
                } 
                
                if (db.Users.Any(u => u.Email.Equals(user.Email, StringComparison.InvariantCultureIgnoreCase)))
                {
                    ModelState.AddModelError("Email",
                                             "There is already an account associated with the email you have provided.");
                    return View(user);
                }

                db.Users.Add(user);
                db.SaveChanges();

                FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);

                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        //
        // GET: /User/Edit/5

        public ActionResult Edit(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null ) {
                return HttpNotFound();
            }

            if (User.Identity.Name != user.UserName)
            {
                return RedirectToAction("Unauthorized", "Home");
            }

            return View(user);
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id = 0)
        {
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        //
        // POST: /User/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
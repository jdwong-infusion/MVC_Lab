using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Lab.Models;
using MVC_Lab.DAL;

namespace MVC_Lab.Controllers
{
    [Authorize]
    public class ChatroomController : Controller
    {
        private InfusionRelayChatContext db = new InfusionRelayChatContext();

        //
        // GET: /Chatroom/

        public ActionResult Index()
        {
            return View(db.Chatrooms.ToList());
        }

        //
        // GET: /Chatroom/Details/5

        public ActionResult Details(int id = 0)
        {
            Chatroom chatroom = db.Chatrooms.Find(id);
            if (chatroom == null)
            {
                return HttpNotFound();
            }
            return View(chatroom);
        }

        //
        // GET: /Chatroom/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Chatroom/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chatroom chatroom)
        {
            if (ModelState.IsValid)
            {
                db.Chatrooms.Add(chatroom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatroom);
        }

        //
        // GET: /Chatroom/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Chatroom chatroom = db.Chatrooms.Find(id);
            if (chatroom == null)
            {
                return HttpNotFound();
            }
            return View(chatroom);
        }

        //
        // POST: /Chatroom/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Chatroom chatroom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatroom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatroom);
        }

        //
        // GET: /Chatroom/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Chatroom chatroom = db.Chatrooms.Find(id);
            if (chatroom == null)
            {
                return HttpNotFound();
            }
            return View(chatroom);
        }

        //
        // POST: /Chatroom/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Chatroom chatroom = db.Chatrooms.Find(id);
            db.Chatrooms.Remove(chatroom);
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
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetTeam_Prj.Models;

namespace AspNetTeam_Prj.Controllers
{
    public class likesController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: likes
        public ActionResult Index(int user_id)
        {
            var likes = db.likes.Where(l => l.user_id == user_id);
            return View(likes.ToList());
        }

        // GET: likes/Details/5
        public ActionResult Details(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var itemid = db.likes.Find(id).item_id;
            return RedirectToAction("Detail", "ItemDetail", new { item_id = itemid, ShowAlreadyLikedModal = false });

            /*
            like like = db.likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
            */
        }
        /*
        // GET: likes/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname");
            return View();
        }

        // POST: likes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "like_id,user_id,item_id")] like like)
        {
            if (ModelState.IsValid)
            {
                db.likes.Add(like);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname", like.user_id);
            return View(like);
        }

        // GET: likes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            like like = db.likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname", like.user_id);
            return View(like);
        }

        // POST: likes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "like_id,user_id,item_id")] like like)
        {
            if (ModelState.IsValid)
            {
                db.Entry(like).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname", like.user_id);
            return View(like);
        }
        */

        // GET: likes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            like like = db.likes.Find(id);
            if (like == null)
            {
                return HttpNotFound();
            }
            return View(like);
        }

        // POST: likes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            like like = db.likes.Find(id);
            db.likes.Remove(like);
            var item = db.Items.Single(i => i.item_id == like.item_id);
            int newcount = Int32.Parse(item.like_count) - 1;
            item.like_count = newcount.ToString();
            db.SaveChanges();
            return RedirectToAction("Index", new {  user_id = like.user_id});
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

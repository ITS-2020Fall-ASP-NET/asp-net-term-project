using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeighTrade.DAL;
using NeighTrade.Models;

namespace NeighTrade.Controllers
{
    public class UsersController : Controller
    {
        private NeighTradeContext db = new NeighTradeContext();

        // GET: Users
        public ActionResult Index()
        {
            return View(db.Users.ToList());
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Email,Password,Fname,Lname,Reputation,AddressId")] User user,
            [Bind(Include = "Address1,Address2,Address3,City,State,PostalCode,Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                var savedAddress = db.Addresses.Add(address);
                user.AddressId = savedAddress.AddressId;
                db.Users.Add(user);
                db.SaveChanges();


                ActionResult result = View("Index");
                Session["UserID"] = user.UserId;
                Session["UserEmail"] = user.Email.ToString();
                Session["UserName"] = user.Fname.ToString();
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,Email,Password,Fname,Lname,Reputation,AddressId")] User user,
            [Bind(Include = "Address1, Address2, Address3, City, State, PostalCode, Country")] Address address)
        {
            if (ModelState.IsValid)
            {
                var oldAddress = db.Addresses.Find(user.AddressId);
                oldAddress.Address1 = address.Address1;
                oldAddress.Address2 = address.Address2;
                oldAddress.Address3 = address.Address3;
                oldAddress.City = address.City;
                oldAddress.State = address.State;
                oldAddress.PostalCode = address.PostalCode;
                oldAddress.Country = address.Country;

                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();

                //return RedirectToAction("Index");
                return RedirectToAction("Details", "Users", new { id = user.UserId });
            }

            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
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
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

using AspNetTeam_Prj.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetTeam_Prj.Controllers
{
    public class SignInController : Controller
    {
        // GET: SignIn
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User objUser) {
            if (ModelState.IsValid) {
                using (DatabaseEntities1 db = new DatabaseEntities1()) {
                    var obj = db.Users.Where(a => a.email.Equals(objUser.email) && a.passwd.Equals(objUser.passwd)).FirstOrDefault();
                    if (obj != null) {
                        Session["UserID"] = obj.email.ToString();
                        Session["UserName"] = obj.fname.ToString();
                        return RedirectToAction("Index", "Home");
                    }
                }
            }

            ViewBag.Message = "Invalid e-mail or password.";

            return View("Index");
        }

        public ActionResult SignOut() {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
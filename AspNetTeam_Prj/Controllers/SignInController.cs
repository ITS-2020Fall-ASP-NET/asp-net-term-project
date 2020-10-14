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
        public ActionResult Index(String nextAction, String nextController) {
            Session["Action"] = nextAction;
            Session["Controller"] = nextController;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignIn(User objUser) {
            ActionResult result = View("Index");

            if (ModelState.IsValid) {
                using (DatabaseEntities1 db = new DatabaseEntities1()) {
                    var obj = db.Users.Where(a => a.email.Equals(objUser.email) && a.passwd.Equals(objUser.passwd)).FirstOrDefault();
                    if (obj != null) {
                        Session["UserID"] = obj.user_id;
                        Session["UserEmail"] = obj.email.ToString();
                        Session["UserName"] = obj.fname.ToString();
                        if (Session["Action"] != null) {
                            result = RedirectToAction(Session["Action"].ToString(), Session["Controller"].ToString());
                        } else {
                            Session["Action"] = Session["Controller"] = null;
                            result = RedirectToAction("Index", "Home");
                        }
                    } else {
                        ViewBag.Message = "Invalid e-mail or password.";
                    }
                }
            }

            return result;
        }

        public ActionResult SignOut() {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NeighTrade.DAL;
using NeighTrade.Models;

namespace NeighTrade.Controllers
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
        public ActionResult SignIn(String Email, String Password) {
            ActionResult result = View("Index");

            if (ModelState.IsValid) {
                using (NeighTradeContext db = new NeighTradeContext()) {
                    var obj = db.Users.Where(a => a.Email.Equals(Email) && a.Password.Equals(Password)).FirstOrDefault();
                    if (obj != null) {
                        Session["UserID"] = obj.UserId;
                        Session["UserEmail"] = obj.Email.ToString();
                        Session["UserName"] = obj.Fname.ToString();
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
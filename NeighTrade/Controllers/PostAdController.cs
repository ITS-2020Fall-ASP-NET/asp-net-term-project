using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeighTrade.DAL;
using NeighTrade.Models;


namespace NeighTrade.Controllers
{
    public class PostAdController : Controller
    {
        private NeighTradeContext db = new NeighTradeContext();

        // GET: PostAd
        public ActionResult Index()
        {
            if (Session["UserId"] == null) {
                return RedirectToAction("Index", "SignIn", new { nextAction = "Index", nextController = "PostAd" });
            }

            //ViewBag.category = new SelectList(db.Categories, "categoryId", "Name");
            //ViewBag.category = Enum.GetValues(typeof(Category));
            return View();
        }

        [HttpPost]
        public ActionResult ImgUpload(HttpPostedFileBase file) {
            if (file != null && file.ContentLength > 0)
                try {
                    string path = Path.Combine(Server.MapPath("~/Content/img/item"),
                    Path.GetFileName(file.FileName));
                    file.SaveAs(path);
                    ViewBag.Message = "File uploaded successfully";
                } catch (Exception ex) {
                    ViewBag.Message = "ERROR:" + ex.Message.ToString();
                }
            else {
                ViewBag.Message = "You have not specified a file.";
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,Name,Category,ListingPrice,Description,ImgPath,ImgFile")] Item item) {
            if (ModelState.IsValid) {
                if (item.ImgFile != null) {
                    string path = Path.Combine(Server.MapPath("~/Content/img/item"), item.UserId + "." + Path.GetFileName(item.ImgFile.FileName));
                    item.ImgPath = item.UserId + "." + item.ImgPath;
                    item.ImgFile.SaveAs(path);
                }
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Detail", "ItemDetail", new { item_id = item.ItemId, ShowAlreadyLikedModal = false });
            }

            //ViewBag.category = new SelectList(db.Categories, "CategoryId", "Name", item.Category);
            ViewBag.user_id = new SelectList(db.Users, "UserId", "Fname", item.UserId);

            return View(item);
        }
    }
}
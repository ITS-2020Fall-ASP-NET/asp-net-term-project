using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetTeam_Prj.Models;


namespace AspNetTeam_Prj.Controllers
{
    public class PostAdController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: PostAd
        public ActionResult Index()
        {
            ViewBag.category = new SelectList(db.Categories, "category_id", "category_name");
            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname");
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
        public ActionResult Create([Bind(Include = "user_id,name,category,listing_price,description,img_path,img_file")] Item item) {
            if (ModelState.IsValid) {
                if (item.img_file != null) {
                    string path = Path.Combine(Server.MapPath("~/Content/img/item"), item.user_id + "." + Path.GetFileName(item.img_file.FileName));
                    item.img_path = item.user_id + "." + item.img_path;
                    item.img_file.SaveAs(path);
                }
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Detail", "ItemDetail", new { item_id = item.item_id, ShowAlreadyLikedModal = false });
            }

            ViewBag.category = new SelectList(db.Categories, "category_id", "category_name", item.category);
            ViewBag.user_id = new SelectList(db.Users, "user_id", "fname", item.user_id);

            return View(item);
        }
    }
}
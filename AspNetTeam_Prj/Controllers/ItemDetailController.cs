using AspNetTeam_Prj.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetTeam_Prj.Controllers
{
    public class ItemDetailController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();
        // GET: ItemDetail
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }
        public ActionResult Detail(int item_id, bool ShowAlreadyLikedModal)
        {
            ViewBag.ShowAlreadyLikedModal = ShowAlreadyLikedModal;
            ViewBag.newLikeId = GetNewLikeId();
            Item item = db.Items.Find(item_id);
            return View(item);
        }

        public ActionResult Like([Bind(Include = "like_id,user_id,item_id")] like like)
        {
            try
            {
                if (ModelState.IsValid && !IsAlreadyLiked(like.user_id, like.item_id))
                {
                    var item = db.Items.Single(i => i.item_id == like.item_id);
                    item.like_count = (Int32.Parse(item.like_count) + 1).ToString();
                    db.likes.Add(like);
                    db.SaveChanges();
                    return RedirectToAction("Detail", "ItemDetail", new { item_id = like.item_id, ShowAlreadyLikedModal = false });
                }
            }catch(DbUpdateException e)
            {
                return RedirectToAction("Detail", "ItemDetail", new { item_id = like.item_id, ShowAlreadyLikedModal = true });
            }
            return RedirectToAction("Detail", "ItemDetail", new { item_id = like.item_id, ShowAlreadyLikedModal = true });
        }
        /*
        private void AddLikeCount(string count, int item_id)
        {
            int like_count = Int32.Parse(count) + 1;
            Item item = db.Items.Find(item_id);
            item.like_count = like_count.ToString();
            //string query2 = "UPDATE item SET like_count=" + like_count.ToString() + "WHERE item_id=" + item_id;
            //var cmd = new SqlCommand(query2, conn);
            //cmd.ExecuteReader();
        }
        */
        private int GetNewLikeId()
        {
            return db.likes.Count() + 1;
        }
        private bool IsAlreadyLiked(int user_id, int item_id)
        {
            var query = db.likes.Where(l => (l.user_id == user_id && l.item_id == item_id));
            return query.Count() != 0;

        }
    }
}
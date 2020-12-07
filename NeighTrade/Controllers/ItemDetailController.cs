using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeighTrade.DAL;
using NeighTrade.Models;

namespace NeighTrader.Controllers
{
    public class ItemDetailController : Controller
    {
        private NeighTradeContext db = new NeighTradeContext();

        // GET: ItemDetail
        public ActionResult Index()
        {
            return View(db.Items.ToList());
        }
        public ActionResult Detail(int item_id, bool ShowAlreadyLikedModal)
        {
            ViewBag.ShowAlreadyLikedModal = ShowAlreadyLikedModal;
            ViewBag.newLikeId = GetNewLikeId();
            ViewBag.newTransactionId = GetNewTransactionId();
            Item item = db.Items.Find(item_id);
            return View(item);
        }

        public ActionResult Like([Bind(Include = "LikeId,UserId,ItemId")] Like like)
        {
            try
            {
                if (ModelState.IsValid && !IsAlreadyLiked(like.UserId, like.ItemId))
                {
                    var item = db.Items.Single(i => i.ItemId == like.ItemId);
                    item.LikeCount = item.LikeCount + 1;
                    db.Likes.Add(like);
                    db.SaveChanges();
                    return RedirectToAction("Detail", "ItemDetail", new { item_id = like.ItemId, ShowAlreadyLikedModal = false });
                }
            } catch (DbUpdateException e)
            {
                return RedirectToAction("Detail", "ItemDetail", new { item_id = like.ItemId, ShowAlreadyLikedModal = true });
            }
            return RedirectToAction("Detail", "ItemDetail", new { item_id = like.ItemId, ShowAlreadyLikedModal = true });
        }

        public ActionResult Buy([Bind(Include = "TransactionId,SellerId,BuyerId,ItemId,Price,Date,Status")] Transaction transaction)
        {
               db.Transactions.Add(transaction);
                db.SaveChanges();
            return RedirectToAction("UserTransactions", "Transactions", new { id=transaction.BuyerId});
        }


        private int GetNewLikeId()
        {
            return db.Likes.Count() + 1;
        }

        private int GetNewTransactionId()
        {
            return db.Transactions.Count() + 1;
        }

        private bool IsAlreadyLiked(int user_id, int item_id)
        {
            var query = db.Likes.Where(l => (l.UserId == user_id && l.ItemId == item_id));
            return query.Count() != 0;

        }

        // GET: Category-Items
        public ActionResult CategoryItems(int category_id)
        {
            Category category = (Category) category_id;
            var items = db.Items.Where(i => (Category) i.Category == category).ToList();
            return View("Index", items);
        }
    }
}
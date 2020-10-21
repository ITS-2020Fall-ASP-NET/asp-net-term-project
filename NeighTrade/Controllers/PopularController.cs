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
    public class PopularController : Controller
    {
        private NeighTradeContext db = new NeighTradeContext();

        // GET: Popular
        public ActionResult Index()
        {
            //var items = db.Items.Include(i => i.Category).Include(i => i.UserId);
            return View(db.Items.ToList());
        }
    }
}
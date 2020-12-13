using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using NeighTrade.DAL;
using NeighTrade.Models;

namespace NeighTrade.Controllers
{
    public class SearchController : Controller
    {
        private NeighTradeContext db = new NeighTradeContext();

        // GET: Search
        public async Task<ActionResult> Index(string searchText)
        {
            var searchResult = db.Items.Where(i => i.Name.Contains(searchText)
                || i.User.Address.City.Contains(searchText)
                || i.User.Address.Address1.Contains(searchText));

            return View(await searchResult.ToListAsync());
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

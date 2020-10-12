using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AspNetTeam_Prj.Models;

namespace AspNetTeam_Prj.Controllers
{
    public class PopularController : Controller
    {
        private DatabaseEntities1 db = new DatabaseEntities1();

        // GET: Popular
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Category1).Include(i => i.User);
            return View(items.ToList());
        }
    }
}
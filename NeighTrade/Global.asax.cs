using NeighTrade.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace NeighTrade
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start() {
            /*
            NeighTradeContext db = new NeighTradeContext();
            db.Database.Initialize(true);
            */

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}

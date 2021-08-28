using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AccountManager.Controllers
{
    public class LayoutController : Controller
    {  
        [OutputCache(Duration = 2592000, VaryByParam = "none")]
        public ActionResult HeaderCssJs()
        {
            return PartialView();
        }

        [OutputCache(Duration = 2592000, VaryByParam = "none")]
        public ActionResult FooterCssJs()
        {
            return PartialView();
        }

        [OutputCache(Duration = 2592000, VaryByParam = "none")]
        public ActionResult DataTableCssJs()
        {
            return PartialView();
        }

        [OutputCache(Duration = 2592000, VaryByParam = "none")]
        public ActionResult DTMultiViewOtherCssJs()
        {
            return PartialView();
        }
		[OutputCache(Duration = 2592000, VaryByParam = "none")]
        public ActionResult DashboardCssJs()
        {
            return PartialView();
        }
    }
}

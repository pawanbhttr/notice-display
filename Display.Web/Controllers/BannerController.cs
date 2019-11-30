using Display.Web.Business;
using Display.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class BannerController : Controller
    {
        DisplayCommon dc = new DisplayCommon();
        BannerBusiness _buss = new BannerBusiness();
        public ActionResult List()
        {
            return View(dc.GetBanner());
        }

        [HttpPost]
        public JsonResult Add(BannerModel model)
        {
            return Json(_buss.SaveOrUpdateBanner(model));
        }

        [HttpPost]
        public JsonResult Display(BannerModel model)
        {
            return Json(_buss.ActivateDeactivate(model));
        }
    }
}
using Display.Web.Business;
using Display.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class NoticeController : Controller
    {
        DisplayCommon dc = new DisplayCommon();
        NoticeBusiness _buss = new NoticeBusiness();
        public ActionResult List()
        {
            return View(dc.GetNotice());
        }

        [HttpPost]
        public JsonResult Add(NoticeModel model)
        {
            return Json(_buss.SaveOrUpdateNotice(model));
        }

        [HttpPost]
        public JsonResult Display(NoticeModel model)
        {
            return Json(_buss.ActivateDeactivate(model));
        }
    }
}
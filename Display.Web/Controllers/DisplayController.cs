using Display.Web.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class DisplayController : Controller
    {
        DisplayBusiness _buss = new DisplayBusiness();
        public ActionResult Index()
        {
            try
            {
                ViewBag.Banner = _buss.GetBanner();
                ViewBag.Notice = _buss.GetNotice();
                return View(_buss.GetCarousel());
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return View();
            }
            
        }
    }
}
using Display.Web.Business;
using Display.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class CarouselController : Controller
    {
        DisplayCommon dc = new DisplayCommon();
        CarouselBusiness _buss = new CarouselBusiness();
        public ActionResult List()
        {
            return View(dc.GetCarousel());
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(CarouselModel model, HttpPostedFileBase fupImage)
        {
            try
            {
                var error = string.Empty;
                model.CreatedBy = DisplayCommon.ToInt32(Session["UserID"]);
                TempData["Message"] = _buss.SaveOrUpdateCarousel(model, fupImage, out error);
                TempData["Error"] = error;
                if (error == "danger")
                    return View();
                
            }
            catch (Exception ex)
            {
                ex.ErrLog();
            }
            return RedirectToAction("List");
        }

        public ActionResult Edit(int? id)
        {
            try
            {
                var model = dc.GetCarousel().Where(m => m.CarouselID == id).FirstOrDefault();
                return View(model);
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return View();
            }
        }

        [HttpPost]
        public ActionResult Edit(CarouselModel model, HttpPostedFileBase fupImage)
        {
            try
            {
                var error = string.Empty;
                TempData["Message"] = _buss.SaveOrUpdateCarousel(model, fupImage, out error);
                TempData["Error"] = error;
                if (error == "danger")
                    return View();
            }
            catch (Exception ex)
            {
                ex.ErrLog();
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public JsonResult Display(CarouselModel model)
        {
            return Json(_buss.ActivateDeactivate(model));
        }

        
    }
}
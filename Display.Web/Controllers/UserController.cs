using Display.Web.Business;
using Display.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class UserController : Controller
    {
        UserBusiness _buss = new UserBusiness();
        DisplayCommon dc = new DisplayCommon();

        public ActionResult List()
        {
            try
            {
                return View(dc.GetUserInfo().Where(i => i.Active == true).ToList());
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return View();
            }
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(UserModel model)
        {
            try
            {
                return AddOrUpdate(model);
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return null;
            }
        }

        public ActionResult Edit(int? id)
        {
            return View(dc.GetUserInfo().Where(i => i.UserID == id).FirstOrDefault());
        }

        [HttpPost]
        public ActionResult Edit(UserModel model)
        {
            try
            {
                return AddOrUpdate(model);
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return null;
            }
        }

        private ActionResult AddOrUpdate(UserModel model)
        {
            try
            {
                var error = string.Empty;
                model.CreatedBy = DisplayCommon.ToInt32(Session["UserID"]);
                TempData["Message"] = _buss.SaveOrUpdateUser(model, out error);
                TempData["Error"] = error;
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public JsonResult CheckUsername(UserModel model)
        {
            try
            {
                var user = dc.GetUserInfo().Where(i => i.Username == model.Username).ToList();
                if (user.Count > 0)
                {
                    return Json("0");
                }
                return Json("1");
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return Json("Error occured while checking username.Please contact system administrator.");
            }
        }

        public JsonResult DeleteUser(UserModel model)
        {
            try
            {
                dc.ActivateDeactive("UserInfo", "Active", 0, "UserID", model.UserID);
                return Json("User deleted successfully");
            }
            catch (Exception ex)
            {
                ex.ErrLog();
                return Json("Error occured while deleting record(s).");
            }
        }
    }
}
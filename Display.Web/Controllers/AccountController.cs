using Display.Web.Business;
using Display.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Display.Web.Controllers
{
    public class AccountController : Controller
    {
        UserBusiness _buss = new UserBusiness();
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            try
            {
                var dt = _buss.UserLogin(model);
                if (dt.Rows.Count > 0)
                {
                    Session["UserID"] = dt.Rows[0]["UserID"];
                    Session["FullName"] = dt.Rows[0]["FullName"];
                    Session["UserRole"] = dt.Rows[0]["UserRole"];
                    return RedirectToAction("Index", "Home");
                }
                ViewBag.Message = "Username or Password doesnot matched.";
            }
            catch (Exception ex)
            {
                ex.ErrLog();
            }
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            return RedirectToAction("Login");
        }
    }
}
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models;

namespace Web.Areas.Admin.Controllers
{
    public class LoginAdController : Controller
    {
        // GET: Admin/LoginAd
        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginAdModel model)
        {
            var result = new AccountDAO().LoginAd(model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                Session.Add("ADMIN_SESSION", model.UserName);
                return RedirectToAction("Index", "HomeAd");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
    }
}
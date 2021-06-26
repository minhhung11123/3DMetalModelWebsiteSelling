using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Areas.Admin.Models;
using Models.DAO;

namespace Web.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login

        [HttpGet]
        public ActionResult Index()
        {
            Session.Clear();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model)
        {
            var dao = new AccountDAO();
            var result = dao.Login(model.UserName, model.Password);
            if (result && ModelState.IsValid)
            {
                Session.Add("USER_SESSION", model.UserName);
                Session.Add("USER_ID_SESSION", dao.GetByName(model.UserName).ID);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tên đăng nhập hoặc mật khẩu không đúng.");
            }
            return View(model);
        }
    }
}
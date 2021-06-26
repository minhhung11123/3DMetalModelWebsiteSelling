using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class RegisterController : Controller
    {
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account ac)
        {
            if (ModelState.IsValid)
            {
                var dao = new AccountDAO();
                bool check = dao.FindUser(ac.UserName);
                if (!check)
                {
                    var res = dao.Insert(ac);
                    if (res > 0)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại.");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Tài khoản tồn tại.");
                }
            }
            return View("Create");
        }
    }
}
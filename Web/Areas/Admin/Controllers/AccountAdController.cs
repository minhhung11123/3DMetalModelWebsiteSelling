using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class AccountAdController : BaseController
    {
        // GET: Admin/AccountAd
        public ActionResult Index()
        {
            var iplAcc = new AccountDAO();
            var model = iplAcc.ListAll();
            return View(model);
        }

        // GET: Admin/AccountAd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/AccountAd/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/AccountAd/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Account collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var dao = new AccountDAO();
                    bool check = dao.FindUser(collection.UserName);
                    if (!check)
                    {
                        var res = dao.InsertAd(collection);
                        if (res > 0)
                        {
                            return RedirectToAction("Index");
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
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AccountAd/Edit/5
        public ActionResult Edit(int id)
        {
            var res = new AccountDAO().ViewDetail(id);
            return View(res);
        }

        // POST: Admin/AccountAd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Account collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = new AccountDAO().Edit(id, collection);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Sửa thất bại");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/AccountAd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/AccountAd/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}

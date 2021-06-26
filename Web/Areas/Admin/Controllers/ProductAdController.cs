using Models.DAO;
using Models.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class ProductAdController : BaseController
    {
        // GET: Admin/ProductAd
        public ActionResult Index()
        {
            var iplProd = new ProductDAO();
            var model = iplProd.ListAll();
            return View(model);
        }

        // GET: Admin/ProductAd/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/ProductAd/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ProductAd/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var model = new ProductDAO();
                    int res = model.Create(collection.Name, collection.Code, collection.MetaTitle,
                        collection.Description, collection.Image, collection.Price, collection.PromotionPrice,
                        collection.IncludedVAT, collection.Quantity, collection.CategoryID, collection.Detail,
                        collection.CreatedDate.HasValue ? collection.CreatedDate : DateTime.Now, collection.CreatedBy, collection.MetaKeywords, 
                        collection.MetaDescriptions, collection.Status);
                    if (res > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Thêm thất bại.");
                    }
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/ProductAd/Edit/5
        public ActionResult Edit(int id)
        {
            var res = new ProductDAO().ViewDetail(id);
            return View(res);
        }

        // POST: Admin/ProductAd/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var res = new ProductDAO().Edit(id, collection);
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

        // GET: Admin/ProductAd/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/ProductAd/Delete/5
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

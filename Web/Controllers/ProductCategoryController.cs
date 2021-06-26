using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace Web.Controllers
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        public ActionResult Index()
        {
            return View();
        } 

        public ActionResult ProductCategory(long id)
        {
            var dao = new ProductCategoryDAO().ViewDetail(id);
            ViewBag.ListProduct3 = new ProductDAO().ListProduct3(id);
            ViewBag.ListProduct6 = new ProductDAO().ListProduct6(id);
            ViewBag.ListProduct9 = new ProductDAO().ListProduct9(id);
            return View(dao);
        }
    }
}
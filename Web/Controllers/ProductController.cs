using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace Web.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult ProductCategory()
        {
            var model = new ProductCategoryDAO().ListAll();
            return PartialView(model);
        }

        public ActionResult Product(long id)
        {
            var dao = new ProductDAO();
            var detail = dao.ViewDetail(id);
            ViewBag.ProductTop = dao.ListProductHomeTop(5);
            return View(detail);
        }
    }
}
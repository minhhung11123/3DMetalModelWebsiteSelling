using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models.DAO;

namespace Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ViewBag.Slide = new SlideDAO().ListAll();
            var productDAO = new ProductDAO();
            ViewBag.ProductTop = productDAO.ListProductHomeTop(3);
            ViewBag.ProductBot = productDAO.ListProductHomeBot(3);
            return View();
        }
    }
}
using Models.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Areas.Admin.Controllers
{
    public class CartAdController : BaseController
    {
        // GET: Admin/CartAd
        public ActionResult Index()
        {
            var iplOrd = new OrderDAO();
            var model = iplOrd.ListAll();
            return View(model);
        }

        // GET: Admin/CartAd/Details/5
        public ActionResult Details(int id)
        {
            var iplOrdDet = new OrderDetailDAO();
            var model = iplOrdDet.ListAll(id);
            return View(model);
        }

        public ActionResult Confirm(int id)
        {
            var res = new OrderDAO().confirm(id);
            return RedirectToAction("Index", "CartAd");
        }
    }
}

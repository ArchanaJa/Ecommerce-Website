using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Repository;

namespace ElectronicsShop.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();

        public ActionResult Index()
        {
            ViewBag.latestProducts = iProductRepository.LatestProducts(4);
            return View();
        }
    }
}
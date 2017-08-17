using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Repository;

namespace ElectronicsShop.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryRepository iCategoryRepository = new CategoryRepository();
        private IProductRepository iProductRepository = new ProductRepository();

        public ActionResult Index()
        {
            ViewBag.products = iProductRepository.LatestProducts().ToList();
            return View("Category");
        }
        public ActionResult Category(int id)
        {
            var category = iCategoryRepository.find(id);
            ViewBag.category = category;
            ViewBag.products = category.Products.ToList();
            return View("Category");
        }
        public ActionResult Latest()
        {
            ViewBag.products = iProductRepository.LatestProducts();
            return View("Latest");
        }
        public ActionResult Specials()
        {
            return View("Specials");
        }

        public ActionResult Details(int id)
        {
            ViewBag.product = iProductRepository.Find(id);
            ViewBag.relatedProducts = iProductRepository.RelatedProducts(iProductRepository.Find(id), 6);
            return View("Details");
        }
    }
}
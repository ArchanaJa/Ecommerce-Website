using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Models;
using System.Net;

namespace ElectronicsShop.Controllers
{
    public class AdminController : Controller
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();
        // GET: Admin
        public ActionResult Index()
        {
            var products = from p in myShopEntities.Products
                              select p;
            return View(products);
        }

        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product products)
        {
            if (ModelState.IsValid)
            {
                myShopEntities.Products.Add(products);
                myShopEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = myShopEntities.Products.Find(id);
            return View(products);
        }

        [HttpPost]
        public ActionResult Edit(Product products)
        {
            if (ModelState.IsValid)
            {
                myShopEntities.Entry(products).State = System.Data.Entity.EntityState.Modified;
                myShopEntities.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product products = myShopEntities.Products.Find(id);
            return View(products);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Product products = myShopEntities.Products.Find(id);
            myShopEntities.Products.Remove(products);
            myShopEntities.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public class ProductRepository : IProductRepository
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();

        public List<Product> RelatedProducts(Product product, int n)
        {
            return myShopEntities.Products.Where(p => p.categoryId == product.categoryId && p.id != product.id).Take(n).ToList();
        }

        public Product Find(int id)
        {
            return myShopEntities.Products.Find(id);
        }

        public List<Product> LatestProducts(int n)
        {
            return myShopEntities.Products.OrderByDescending(p => p.id).Take(n).ToList();
        }

        public List<Product> LatestProducts()
        {
            return myShopEntities.Products.OrderByDescending(p => p.id).ToList();
        }
    }
}
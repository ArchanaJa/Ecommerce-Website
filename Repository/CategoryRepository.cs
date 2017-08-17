using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();

        public Category find(int id)
        {
            return myShopEntities.Categories.Find(id);
        }

        public List<Category> findAll()
        {
            return myShopEntities.Categories.ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public class OrdersRepository : IOrdersRepository
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();

        public int create(Order order)
        {
            this.myShopEntities.Orders.Add(order);
            this.myShopEntities.SaveChanges();
            return order.Id;
        }

        


    }
}
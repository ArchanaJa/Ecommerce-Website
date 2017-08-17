using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();

        public void create(OrderDetail orderDetail)
        {
            this.myShopEntities.OrderDetails.Add(orderDetail);
            this.myShopEntities.SaveChanges();
            
        }
        public Order Find(int Id)
        {
            return this.myShopEntities.Orders
                .Include("OrderDetails")
                
                .FirstOrDefault(o => o.Id == Id);
            

        }
    }
}
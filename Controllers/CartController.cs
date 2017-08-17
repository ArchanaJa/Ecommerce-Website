using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Repository;
using ElectronicsShop.Models;

namespace ElectronicsShop.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository iProductRepository = new ProductRepository();
        private IOrdersRepository iOrdersRepository = new OrdersRepository();
        private IOrderDetailRepository iOrderDetailRepository = new OrderDetailRepository();

        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Buy(int id)
        {
            if (Session["cart"] == null)
            {
                List<Item> cart = new List<Item>();
                cart.Add(new Item()
                {
                    product = iProductRepository.Find(id),
                    quantity = 1
                });
                Session["cart"] = cart;
            }
            else
            {
                List<Item> cart = (List<Item>)Session["cart"];
                int index = isExits(id);
                if (index == -1)
                {
                    cart.Add(new Item()
                    {
                        product = iProductRepository.Find(id),
                        quantity = 1
                    });
                }
                else
                {
                    cart[index].quantity = cart[index].quantity + 1;
                }
                Session["cart"] = cart;
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            cart.RemoveAt(id);
            Session["cart"] = cart;
            return View("Index");
        }

        private int isExits(int id)
        {
            List<Item> cart = (List<Item>)Session["cart"];
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].product.id == id)
                    return i;
            return -1;

        }

        [HttpPost]
        public ActionResult SaveOrder(Order order)
        {
            // SAve order in DB
            //Repository.Save(order);

            // Order Table - 1 Entry
            // Order DEtails Tables - x items
            return View("Thanks", order);
        }

        public ActionResult Checkout()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("MyAccount", "Account");
            }

            List<Item> cart = (List<Item>)Session["cart"];
            //save order
            Order order = new Order();
            order.CreationDate = DateTime.Now;
            order.Name = "New Order";
            order.Payment = "Paypal";
            order.Username = Session["username"].ToString();
            int orderId = iOrdersRepository.create(order);

            //save order detail
            foreach (var item in cart)
            {

                OrderDetail orderDetail = new OrderDetail();
                orderDetail.OrderId = orderId;
                orderDetail.ProductId = item.product.id;
                orderDetail.Price = item.product.price;
                orderDetail.quantity = item.quantity;
                //orderDetail.Name = item.product.name;
                iOrderDetailRepository.create(orderDetail);
            }
            //remove cart
            Session["order"] = Session["cart"];
            Session.Remove("cart");

            // Fetch Saved DEtails
            //var o = iOrderDetailRepository.Find(orderId);
            return View("Thanks");

            
        }
    }
}
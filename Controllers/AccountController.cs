using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsShop.Models;
using ElectronicsShop.Repository;

namespace ElectronicsShop.Controllers
{
    public class AccountController : Controller
    {
        private IAccountRepository iAccountRepository = new AccountRepository();
        
        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(Account account)
        {
            iAccountRepository.create(account);
            //account.Role = "user";
            return RedirectToAction("MyAccount", "Account");
        }
        public ActionResult MyAccount()
        {
            return View("MyAccount");
        }

        [HttpPost]
        public ActionResult MyAccount(Account account)
        {
            Account acc = iAccountRepository.login(account.Username, account.Password);
            if (acc == null)
            {
                ViewBag.error = "Account is invalid";
                return View("MyAccount");
            }
            else
            {
                Session["username"] = acc.Username;
                Session["role"] = acc.Role;

                if (acc.Role == "admin")
                {
                    return RedirectToAction("Index", "Admin");
                }
                else if (acc.Role == "user" || acc.Role == null)
                {
                    return RedirectToAction("Latest", "Product");
                }
                else
                {
                    return View("Welcome");
                }
            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("MyAccount", "Account");
        }
    }
}
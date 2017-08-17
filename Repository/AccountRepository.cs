using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ElectronicsShop.Models;

namespace ElectronicsShop.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private MyShopEntities4 myShopEntities = new MyShopEntities4();

        public void create(Account account)
        {
            myShopEntities.Accounts.Add(account);
            myShopEntities.SaveChanges();
        }

        public Account login(string username, string password)
        {
            try
            {
                return myShopEntities.Accounts.Single(account => account.Username.Equals(username) && account.Password.Equals(password));
            }
            catch
            {
                return null;
            }
        }
    }
}
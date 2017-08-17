using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElectronicsShop.Extensions
{
    public static class Utils
    {
        public static bool IsAdmin(this HtmlHelper html)
        {
            HttpContext context = HttpContext.Current;
            return context.Session["Role"] != null && context.Session["Role"].ToString() == "admin";
        }
    }
}
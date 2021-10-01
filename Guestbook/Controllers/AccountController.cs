using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            return View();
        }

        public ActionResult ChangePassword(ChangePasswordModel model, string returnUrl)
        {
            return View();
        }
    }
}
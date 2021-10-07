using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

/*You need to have an action method with that name in your ErrorController. The request will be directed to the action method, not to the view file. 
    Your action method can return that view (or any other view)*/

// https://stackoverflow.com/questions/40183208/asp-net-mvc-5-system-doesnt-find-a-view-that-exists

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller // inherits from Controller
    {
        private GuestbookContext _db = new GuestbookContext();

        public ActionResult Index() // exposes public action method
        {
            var mostRecentEntries =
                (from entry in _db.Entries
                 orderby entry.DateAdded descending 
                 select entry).Take(20);

            // ViewBag.Entries = mostRecentEntries.ToList();

            // using strongly typed approach

            var model = mostRecentEntries.ToList();

            return View(model);
        }


        // GET: Guestbook

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost] // restrict access to HTTP post [HttpPost] is a decorator. Accept GuestbookEntry as parameter
        public ActionResult Create(GuestbookEntry entry) // Method overloading (Originally Create() above)
        {
            entry.DateAdded = DateTime.Now;
            _db.Entries.Add(entry);
            _db.SaveChanges();

            return RedirectToAction("Index"); // because Index is an action
        }

        public ViewResult Show( int id )
        {
            var entry = _db.Entries.Find(id);

            bool hasPermission = User.Identity.Name == entry.Name;

            ViewData["hasPermission"] = hasPermission;

            return View(entry);
        }
    }
}
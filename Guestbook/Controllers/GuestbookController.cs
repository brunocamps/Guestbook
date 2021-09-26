using Guestbook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class GuestbookController : Controller
    {
        private GuestbookContext _db = new GuestbookContext();

        public ActionResult Index()
        {
            var mostRecentEntries =
                (from entry in _db.Entries
                 orderby entry.DateAdded descending 
                 select entry).Take(20);

            ViewBag.Entries = mostRecentEntries.ToList();
            return View();
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
    }
}
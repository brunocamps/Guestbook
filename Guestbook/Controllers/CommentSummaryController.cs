using System;
using Guestbook.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Guestbook.Controllers
{
    public class CommentSummaryController : Controller
    {

        private GuestbookContext _db = new GuestbookContext();
        // GET: CommentSummary
        public ActionResult CommentSummary()
        {


            var entries = from entry in _db.Entries
                          group entry by entry.Name
                          into groupedByName
                          orderby groupedByName.Count() descending
                          select new CommentSummary
                          {
                              NumberOfComments =
                                groupedByName.Count(),
                              UserName = groupedByName.Key
                          };

            return View(entries.ToList());
        }
    }
}
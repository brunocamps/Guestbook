using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Guestbook.Models
{
    public class GuestbookContext : DbContext
    {
        public GuestbookContext() : base("Guestbook")
        {

        }
        public DbSet<GuestbookEntry> Entries { get; set; }
    }
}
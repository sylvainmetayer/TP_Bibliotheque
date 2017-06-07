using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models
{
    public class BDDContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }

        public DbSet<Member> Members { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BooksBorrowing> BooksBorrowing { get; set; }

    }
}
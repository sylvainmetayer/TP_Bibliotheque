using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models
{
    public class AuthorModelView
    {
        private List<Author> Authors;

        public AuthorModelView(List<Author> authors)
        {
            this.Authors = authors;
        }

        public List<Author> GetAuthors()
        {
            return this.Authors;
        }
    }
}
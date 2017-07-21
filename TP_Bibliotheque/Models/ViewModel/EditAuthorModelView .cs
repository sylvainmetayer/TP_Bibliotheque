using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class EditAuthorModelView
    {
        private List<Author> Authors;
        public Author author { get; set; } // Pour récupérer l'entité de l'auteur
        public int id;

        public List<Author> GetAuthors()
        {
            return this.Authors;
        }

    }
}
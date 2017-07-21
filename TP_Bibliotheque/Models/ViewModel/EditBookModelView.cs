using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class EditBookModelView
    {
        public Book book { get; set; } // Pour récupérer l'entité du livre
        private Book BookUse;
        public int authorSelected { get; set; } // Pour récupérer l'auteur du livre
        public IEnumerable<SelectListItem> authors { get; set; }
        public int id;


        public Book getBook()
        {
            return this.BookUse;
        }
    }
}
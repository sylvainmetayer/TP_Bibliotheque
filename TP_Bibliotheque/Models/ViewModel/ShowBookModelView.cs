using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class ShowBookModelView
    {
        private Book Book;

        public ShowBookModelView(Book member)
        {
            this.Book = member;
        }

        public Book getBook()
        {
            return this.Book;
        }
    }
}
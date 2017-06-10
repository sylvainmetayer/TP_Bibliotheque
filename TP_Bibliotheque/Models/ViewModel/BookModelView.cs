using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class BookModelView
    {
        private List<Book> Books;

        public BookModelView(List<Book> books)
        {
            this.Books = books;
        }

        public List<Book> GetBooks()
        {
            return this.Books;
        }
    }
}
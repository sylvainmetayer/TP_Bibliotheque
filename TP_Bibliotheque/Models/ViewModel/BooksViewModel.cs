using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class BooksViewModel
    {
        public List<Book> Books { get; private set; }

        public BooksViewModel()
        {
            Books = new List<Book>();
        }
    }
}
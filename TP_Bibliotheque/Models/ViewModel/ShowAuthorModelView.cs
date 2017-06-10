using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class ShowAuthorModelView
    {
        private Author Author;
        private List<Book> Books; // Books of this author

        public ShowAuthorModelView(Author author, List<Book> Books)
        {
            this.Author = author;
            this.Books = Books;
        }

        public Author getAuthor()
        {
            return this.Author;
        }

        public List<Book> getAuthorBooks()
        {
            return this.Books;
        }
        
    }
}
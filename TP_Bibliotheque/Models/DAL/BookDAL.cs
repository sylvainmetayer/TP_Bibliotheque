using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.DAL
{
    public class BookDAL : IDal<Book>
    {
        private List<Book> Books;

        public BookDAL(List<Book> books)
        {
            this.Books = books;
        }

        public void Add(Book element)
        {
            if (element != null)
            {
                element.Id = BaseUser.IdMax;
                BaseUser.IdMax++;
                this.Books.Add(element);
            }
        }

        public void Delete(int id)
        {
            this.Books.Remove(Read(id));
        }

        public void DeleteAll()
        {
            this.Books = new List<Book>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Book> GetAll()
        {
            return this.Books;
        }

        internal List<Book> GetAvailableBooks()
        {
            return this.Books.FindAll(x => x.AvailableQuantity > 0);
        }

        public Book Read(int id)
        {
            return this.Books.Find(x => x.Id == id);
        }

        public List<Book> FindByAuthor(Author author)
        {
            return this.Books.FindAll(x => x.Author.Id == author.Id);
        }

        public void Update(int id, Book element)
        {
            var itemIndex = this.Books.FindIndex(x => x.Id == id);
            var item = this.Books.ElementAt(itemIndex);
            this.Books.RemoveAt(itemIndex);
            item = element;
            this.Books.Insert(itemIndex, item);
        }
    }
}
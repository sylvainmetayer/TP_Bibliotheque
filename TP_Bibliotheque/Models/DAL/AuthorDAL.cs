using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.DAL
{
    public class AuthorDAL : IDal<Author>
    {
        private List<Author> Authors;

        public AuthorDAL(List<Author> authors)
        {
            this.Authors = authors;
        }

        public void Add(Author element)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Author> GetAll()
        {
            return this.Authors;
        }

        public Author Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Author element)
        {
            throw new NotImplementedException();
        }
    }
}
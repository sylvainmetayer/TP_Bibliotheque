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
            if (element != null)
            {
                element.Id = BaseUser.IdMax;
                BaseUser.IdMax++;
                this.Authors.Add(element);
            }
        }

        public void Delete(int id)
        {
            this.Authors.Remove(Read(id));
        }

        public void DeleteAll()
        {
            this.Authors = new List<Author>();
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
            return this.Authors.Find(x => x.Id == id);
        }

        public void Update(int id, Author element)
        {
            var itemIndex = this.Authors.FindIndex(x => x.Id == id);
            var item = this.Authors.ElementAt(itemIndex);
            this.Authors.RemoveAt(itemIndex);
            item = element;
            this.Authors.Insert(itemIndex, item);
        }
    }
}
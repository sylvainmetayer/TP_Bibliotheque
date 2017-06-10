using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.DAL
{
    public class MemberDAL : IDal<Member>
    {
        private List<Member> Books;

        public MemberDAL(List<Member> members)
        {
            this.Books = members;
        }

        public void Add(Member element)
        {
            if (element != null)
            {
                element.Id = Book.IdMax;
                Book.IdMax++;
                this.Books.Add(element);
            }
        }

        public void Delete(int id)
        {
            this.Books.Remove(Read(id));
        }

        public void DeleteAll()
        {
            this.Books = new List<Member>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<Member> GetAll()
        {
            return this.Books;
        }

        public Member Read(int id)
        {
            return this.Books.Find(x => x.Id == id);
        }

        public void Update(int id, Member element)
        {
            var itemIndex = this.Books.FindIndex(x => x.Id == id);
            var item = this.Books.ElementAt(itemIndex);
            this.Books.RemoveAt(itemIndex);
            item = element;
            this.Books.Insert(itemIndex, item);
        }
    }
}
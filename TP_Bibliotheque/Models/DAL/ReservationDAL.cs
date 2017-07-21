using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.DAL
{
    public class ReservationDAL : IDal<BooksBorrowing>
    {
        private List<BooksBorrowing> Reservations;

        public ReservationDAL(List<BooksBorrowing> reservations)
        {
            this.Reservations = reservations;
        }

        public void Add(BooksBorrowing element)
        {
            if (element != null)
            {
                element.Id = BooksBorrowing.IdMax;
                BooksBorrowing.IdMax++;
                this.Reservations.Add(element);
            }
        }

        public void Delete(int id)
        {
            this.Reservations.Remove(Read(id));
        }

        public void DeleteAll()
        {
            this.Reservations = new List<BooksBorrowing>();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public List<BooksBorrowing> GetAll()
        {
            return this.Reservations;
        }

        public BooksBorrowing Read(int id)
        {
            return this.Reservations.Find(x => x.Id == id);
        }

        public void Update(int id, BooksBorrowing element)
        {
            var itemIndex = this.Reservations.FindIndex(x => x.Id == id);
            var item = this.Reservations.ElementAt(itemIndex);
            this.Reservations.RemoveAt(itemIndex);
            item = element;
            this.Reservations.Insert(itemIndex, item);
        }
    }
}
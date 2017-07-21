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

                element.beginDate = DateTime.Now;

                if (element.returnDate != null)
                {
                    // Return date has already be defined, it's the generation of fake data.
                    // Do nothing in this case.
                }
                else
                {
                    DateTime now = DateTime.Now;
                    element.returnDate = now.AddDays(10);
                    element.isReturned = false;
                    element.daysRetard = 0;
                }

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

        internal List<BooksBorrowing> GetByMember(Member member)
        {

            List<BooksBorrowing> result = new List<BooksBorrowing>();
            foreach (BooksBorrowing resa in this.Reservations)
            {
                if (resa.user == member)
                {
                    result.Add(resa);
                }
            }

            return result;
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
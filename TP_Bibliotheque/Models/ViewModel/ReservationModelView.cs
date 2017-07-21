using System.Collections.Generic;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class ReservationModelView
    {
        private List<BooksBorrowing> Reservations;

        public ReservationModelView(List<BooksBorrowing> reservations)
        {
            this.Reservations = reservations;
        }

        public List<BooksBorrowing> GetReservations()
        {
            return this.Reservations;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class ShowMemberModelView
    {
        private Member Member;

        public List<BooksBorrowing> Reservations { get; set; }

        public ShowMemberModelView(Member member)
        {
            this.Member = member;
        }

        public Member getMember()
        {
            return this.Member;
        }

        public List<BooksBorrowing> GetReservations()
        {
            return this.Reservations;
        }
    }
}
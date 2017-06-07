using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_Bibliotheque.Models.Data
{
    public class Member : BaseUser
    {
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }

        public List<BooksBorrowing> BooksBorrowed;


    }
}
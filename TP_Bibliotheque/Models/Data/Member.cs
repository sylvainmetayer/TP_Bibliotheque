using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TP_Bibliotheque.Models.Data
{
    public class Member : BaseUser
    {
        [Required(ErrorMessage = "L'email est obligatoire")]
        public String Email { get; set; }
        public DateTime BirthDate { get; set; }

        public List<BooksBorrowing> BooksBorrowed;


    }
}
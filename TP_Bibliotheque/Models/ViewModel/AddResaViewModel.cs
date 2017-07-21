using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Models.ViewModel
{
    public class AddResaViewModel
    {
        public BooksBorrowing resa { get; set; }
        public int memberSelected { get; set; }
        public int bookSelected { get; set; }

        public IEnumerable<SelectListItem> members { get; set; }
        public IEnumerable<SelectListItem> books { get; set; }
    }
}
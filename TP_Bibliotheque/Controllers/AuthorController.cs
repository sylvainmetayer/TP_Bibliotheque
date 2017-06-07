using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Controllers
{
    public class AuthorController : Controller
    {
        public List<Author> authors;

        // GET: Author
        public ActionResult Index()
        {
            authors = (List<Author>)Session["Authors"];
            return View(authors);
        }
    }
}
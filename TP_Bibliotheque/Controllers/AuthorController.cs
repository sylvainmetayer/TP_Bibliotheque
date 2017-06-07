using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Bibliotheque.Models;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Controllers
{
    public class AuthorController : Controller
    {
        private AuthorModelView modelView;
        private AuthorDAL dal;

        public AuthorController()
        {
            // TODO Find a way to instanciate this, because it's easier to use than instanciate on the fly in methods
            //dal = new AuthorDAL((List<Author>)Session["Authors"]);
        }

        // GET: Author
        public ActionResult Index()
        {
            modelView = new AuthorModelView((List<Author>)Session["Authors"]);

            return View(modelView);
        }

        public ActionResult Add()
        {
            Author author = new Author();

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Firstname")]Author author)
        {
            AuthorDAL dal = new AuthorDAL((List<Author>)Session["Authors"]);
            if (ModelState.IsValid)
            {
                dal.Add(author);
                return RedirectToAction("Index");
            }

            return View(author);
        }
    }
}
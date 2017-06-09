using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP_Bibliotheque.Models;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;

namespace TP_Bibliotheque.Controllers
{
    public class BookController : Controller
    {

        private BookModelView modelView;
        private BookDAL dal;
        private AuthorDAL authorDAL;

        public BookController()
        {
            // TODO Find a way to instanciate this, because it's easier to use than instanciate on the fly in methods
            //dal = new BookDAL((List<Book>)Session["Books"]);
        }

        // GET: Book
        public ActionResult Index()
        {
            modelView = new BookModelView((List<Book>)Session["Books"]);

            return View(modelView);
        }

        public ActionResult Add()
        {
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            List<Author> authors = authorDAL.GetAll();

            var model = new AddBookViewModel();
            model.authors = GetSelectListItems(authors);
            model.book = new Book();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "book, authorSelected")]AddBookViewModel model)
        {
            BookDAL dal = new BookDAL((List<Book>)Session["Books"]);

            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            List<Author> authors = authorDAL.GetAll();
            model.authors = GetSelectListItems(authors);

            if (ModelState.IsValid)
            {
                Author selectedAuthor = authorDAL.Read(model.authorSelected);
                // FIXME "La référence d'objet n'est pas définie à une instance d'un objet" .... NullPointerException sur selectedAuthor ><
                // Il semblerait que l'erreur vienne du read du DAL (mais pas sur)
                model.book.Author = selectedAuthor;
                dal.Add(model.book);
                return RedirectToAction("Index");
            }

            return View("Add", model);
        }

        // FROM http://nimblegecko.com/using-simple-drop-down-lists-in-ASP-NET-MVC/
        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<Author> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element.Id.ToString(),
                    Text = element.Firstname + " " + element.Name
                });
            }

            return selectList;
        }
    }
}
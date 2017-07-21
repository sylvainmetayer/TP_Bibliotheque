using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TP_Bibliotheque.Models;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;
using TP_Bibliotheque.Models.ViewModel;

namespace TP_Bibliotheque.Controllers
{
    public class BookController : Controller
    {
        public BookController()
        {
            // TODO Find a way to instanciate this, because it's easier to use than instanciate on the fly in methods
            //dal = new BookDAL((List<Book>)Session["Books"]);
        }

        // GET: Book
        public ActionResult Index()
        {
            BookModelView modelView = new BookModelView((List<Book>)Session["Books"]);

            return View(modelView);
        }

        public ActionResult Add() // Pour l'ajout d'un nouveau livre
        {
            // Récupération des informations sur l'auteur via le form + ajout au model
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            List<Author> authors = authorDAL.GetAll();

            var model = new AddBookViewModel();
            model.authors = GetSelectListItems(authors);
            model.book = new Book();
            return View(model);
        }
        
        public ActionResult Edit(int id) // Pour l'édition d'un livre
        {
            // Récupération des infos sur l'auteur
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            List<Author> authors = authorDAL.GetAll();

            // Récupération des infos sur le livre
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);
            Book book = bookDAL.Read(id);

            bookDAL.Update(id, book); // MAJ du livre

            //Données mises à jour renvoyées dans la vue
            var model = new EditBookModelView();
            model.book = book;
            model.authors = GetSelectListItems(authors);

            // Données retournée à la vue
            return View(model);
        }


        public ActionResult Details(int id) // Affichage des informations d'un livre
        {
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);

            Book book = bookDAL.Read(id); // R2cupération des infos d'un livre pour un id donné
            ShowBookModelView model = new ShowBookModelView(book);
            return View(model);
        }

        public ActionResult Delete(int id) // Affichage des informations d'un livre
        {
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);

            Book book = bookDAL.Read(id); // R2cupération des infos d'un livre pour un id donné
            bookDAL.Delete(id);

            BookModelView model = new BookModelView((List<Book>)Session["Books"]);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Création d'un livre à partir d'infos récupéré via un form
        public ActionResult Create([Bind(Include = "book, authorSelected")]AddBookViewModel model)
        {
            // Récupération des datas
            BookDAL dal = new BookDAL((List<Book>)Session["Books"]);
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);

            List<Author> authors = authorDAL.GetAll();

            model.authors = GetSelectListItems(authors); // Récupération de l'auteur
            Author selectedAuthor = authorDAL.Read(model.authorSelected);
            model.book.Author = selectedAuthor; // Ajout de l'auteur au model

            if (ModelState.IsValid)
            {
                dal.Add(model.book); // Ajout du livre
                return RedirectToAction("Index"); // Si tout se passe bien, afficher liste livre
            }

            return View("Add", model); // Si erreur, laissez la view d'ajout
        }


        [HttpPost]
        [ValidateAntiForgeryToken] // Pour l'édition d'un livre
        public ActionResult Edition( [Bind(Include = "book, authorSelected")]EditBookModelView model)
        {
            // Récupération des datas
            BookDAL dal = new BookDAL((List<Book>)Session["Books"]);
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            List<Author> authors = authorDAL.GetAll();

            model.authors = GetSelectListItems(authors);
            Author selectedAuthor = authorDAL.Read(model.authorSelected);
            model.book.Author = selectedAuthor;  // Attribuer l'auteur

            if (ModelState.IsValid)
            {
                dal.Update(model.book.Id, model.book); // Mise à jour des datas du livres
                return RedirectToAction("Index"); // Si déroulement OK, retour à la liste de livres
            }

            return View("Edit", model); // Si erreur, on reste sur le formulaire d'edition
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
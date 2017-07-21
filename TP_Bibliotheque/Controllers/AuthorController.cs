using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Bibliotheque.Models;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;
using TP_Bibliotheque.Models.ViewModel;

namespace TP_Bibliotheque.Controllers
{
    public class AuthorController : Controller
    {

        public AuthorController()
        {
            // TODO Find a way to instanciate this, because it's easier to use than instanciate on the fly in methods
            //dal = new AuthorDAL((List<Author>)Session["Authors"]);
        }

        // GET: Author
        public ActionResult Index() // Pour afficher la liste de tous les auteurs
        {
            AuthorModelView modelView = new AuthorModelView((List<Author>)Session["Authors"]);

            return View(modelView);
        }

        public ActionResult Details(int id) // Pour afficher toutes les infos d'un auteur en particulier
        {
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]); // Récupération des auteurs (général)
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]); // Récupération des livres (général)

            Author author = authorDAL.Read(id); // Récupération de l'auteur en particulier

            //Création d'une modelView avec l'auteur + ses livres
            ShowAuthorModelView model = new ShowAuthorModelView(author, bookDAL.FindByAuthor(author)); 
            return View(model);
        }

        public ActionResult Edit(int id) // Edition des informations d'un auteur
        {
            // Récupération des auteurs
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);

            Author author = authorDAL.Read(id); // Lecture des datas de l'auteur en question
            var model = new EditAuthorModelView(); // Création de la modelView de l'edition de l'auteur
            model.author = author; // Ajout de l'auteur a la modelView
            return View(model);
        }

        public ActionResult Add() // Ajout d'un nouvel auteur
        {
            Author author = new Author();

            return View(author);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Création d'un nouvel auteur
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

        [HttpPost]
        [ValidateAntiForgeryToken] // Edition d'un auteur existant
        public ActionResult Edition([Bind(Include = "author")]EditAuthorModelView model) // On  récupére l'entity Autheur spécial EditAuthorModelView
        {
            // Récupération des datas d'auteurs
            AuthorDAL dal = new AuthorDAL((List<Author>)Session["Authors"]);
            if (ModelState.IsValid)
            {
                dal.Update(model.author.Id, model.author); // Mise à jour des datas de l'auteur
                return RedirectToAction("Index"); // Retourner à la liste des auteurs si OK
            }

            return View("Edit", model); // Rester sur le formulaire d'edition
        }


    }
}
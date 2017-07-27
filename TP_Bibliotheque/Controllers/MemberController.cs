using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;
using TP_Bibliotheque.Models.ViewModel;

namespace TP_Bibliotheque.Controllers
{
    public class MemberController : Controller
    {
        // GET: Member
        public ActionResult Index() // Afficher tous les membres
        {
            var dal = new MemberDAL((List<Member>)Session["Members"]);
            var model = new MembersModelView(dal.GetAll());
            return View(model);
        }

        public ActionResult Details(int id) // Affichage des détails d'un membre
        {
            // Récupération des datas du membre : ses données, ses livres emprunté et les datas des livres emprunté
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);
            ReservationDAL resaDAL = new ReservationDAL((List<BooksBorrowing>)Session["BooksBorrowing"]);

            // Lecture des données du membre selectionne
            Member member = memberDAL.Read(id);
            ShowMemberModelView model = new ShowMemberModelView(member); // Creation de la view d'affichage
            model.Reservations = resaDAL.GetByMember(member); // Récupération des réservations

            return View(model);
        }

        public ActionResult Delete(int id) // Suppression d'un membre
        {
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);

            Member member = memberDAL.Read(id); // R2cupération des infos d'un livre pour un id donné
            memberDAL.Delete(id); // Suppression

            MembersModelView model = new MembersModelView((List<Member>)Session["Members"]);
            return View(model); // Retour à la liste des membres
        }

        public ActionResult Edit(int id) // Pour l'édition du membre
        {
            // Récupération des données de membres + lecture data du membre sélectionné
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);
            Member member = memberDAL.Read(id);

            var model = new EditMemberModelView(); // Création du model d'édition
            model.member = member; // Ajout du membre au model d'edition

            return View(model); // Retour dans la vue des données
        }

        public ActionResult Add() //Ajout d'un nouveau membre
        {
            Member member = new Member();

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Création d'un nouveau membre
        public ActionResult Create([Bind(Include = "Name, Firstname, BirthDate, Email")]Member member)
        {
            // Récupération des datas des membres
            MemberDAL dal = new MemberDAL((List<Member>)Session["Members"]);
            if (ModelState.IsValid)
            {
                dal.Add(member); //Ajour du nouveau membre à la liste de membres
                return RedirectToAction("Index"); // Retour à la liste des membres
            }

            return RedirectToAction("Add"); // Sinon, rester sur le formulaire d'ajout
        }

        [HttpPost]
        [ValidateAntiForgeryToken] // Pour l'édition d'un membre
        public ActionResult Edition([Bind(Include = "member")]EditMemberModelView model) // Passage en paramètre de l'entité membre
        {
            //Récupération des datas membres
            MemberDAL dal = new MemberDAL((List<Member>)Session["Members"]);
            if (ModelState.IsValid)
            {
                dal.Update(model.member.Id, model.member); // Mise a jour des datas du membre
                return RedirectToAction("Index"); // SI ok, retourner liste des membres
            }

            return View("Edit", model); // Rester sur le formulaire d'edition
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP_Bibliotheque.Models;
using TP_Bibliotheque.Models.Data;
using TP_Bibliotheque.Models.ViewModel;

namespace TP_Bibliotheque.Controllers
{
    public class HomeController : Controller
    {
        private AuthorModelView modelView;

        public ActionResult Index()
        {
            // Variable de session pour la liste d'auteurs, livres, membres & emprunt.
            modelView = new AuthorModelView((List<Author>)Session["Authors"]);

            return View(modelView);
        }

        public ActionResult About()
        {
            ViewBag.Message = "A propos";

            return View();
        }
    }
}
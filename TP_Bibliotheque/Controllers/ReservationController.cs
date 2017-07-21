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
    public class ReservationController : Controller
    {

        public ReservationController()
        {
            // TODO Find a way to instanciate this, because it's easier to use than instanciate on the fly in methods
            //dal = new AuthorDAL((List<Author>)Session["Authors"]);
        }

        // GET: Reservation
        public ActionResult Index()
        {
            ReservationModelView modelView = new ReservationModelView((List<BooksBorrowing>)Session["BooksBorrowing"]);

            return View(modelView);
        }
        /*
        public ActionResult Details(int id)
        {
            ReservationDAL dal = new ReservationDAL((List<BooksBorrowing>)Session["BooksBorrowing"]);

            BooksBorrowing author = dal.Read(id);
            ShowReservationModelView model = new ShowReservationModelView(author);
            return View(model);
        }

        public ActionResult Add()
        {
            BooksBorrowing reservation = new BooksBorrowing();

            return View(reservation);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user, book")]BooksBorrowing reservation)
        {
            ReservationDAL dal = new ReservationDAL((List<BooksBorrowing>)Session["BooksBorrowing"]);
            if (ModelState.IsValid)
            {
                dal.Add(reservation);
                return RedirectToAction("Index");
            }

            return View(reservation);
        }*/
    }
}
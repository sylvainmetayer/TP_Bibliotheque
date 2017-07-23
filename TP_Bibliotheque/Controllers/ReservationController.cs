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

        public ReservationController() { }

        public ActionResult Index()
        {
            ReservationModelView modelView = new ReservationModelView((List<BooksBorrowing>)Session["BooksBorrowing"]);
            return View(modelView);
        }

        public ActionResult Add()
        {
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);
            List<Member> members = memberDAL.GetAll();

            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);
            List<Book> books = bookDAL.GetAvailableBooks();

            var model = new AddResaViewModel();
            model.members = GetSelectListItemsMember(members);
            model.books = GetSelectListItemsBook(books);
            model.resa = new BooksBorrowing();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "user, book, bookSelected, memberSelected")]AddResaViewModel model)
        {
            ReservationDAL dal = new ReservationDAL((List<BooksBorrowing>)Session["BooksBorrowing"]);
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);

            List<Member> members = memberDAL.GetAll();
            List<Book> books = bookDAL.GetAll();

            model.members = GetSelectListItemsMember(members);
            model.books = GetSelectListItemsBook(books);

            model.resa = new BooksBorrowing();

            Book selectedBook = bookDAL.Read(model.bookSelected);
            model.resa.book = selectedBook;

            selectedBook.AvailableQuantity -= 1;
            bookDAL.Update(selectedBook.Id, selectedBook);

            Member selectedMember = memberDAL.Read(model.memberSelected);
            model.resa.user = selectedMember;

            if (ModelState.IsValid)
            {
                dal.Add(model.resa);
                return RedirectToAction("Index");
            }

            return View("Add", model);
        }

        // FROM http://nimblegecko.com/using-simple-drop-down-lists-in-ASP-NET-MVC/
        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItemsMember(IEnumerable<Member> elements)
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

        // FROM http://nimblegecko.com/using-simple-drop-down-lists-in-ASP-NET-MVC/
        // This is one of the most important parts in the whole example.
        // This function takes a list of strings and returns a list of SelectListItem objects.
        // These objects are going to be used later in the SignUp.html template to render the
        // DropDownList.
        private IEnumerable<SelectListItem> GetSelectListItemsBook(IEnumerable<Book> elements)
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
                    Text = element.Title + " (" + element.Author.Name + ")"
                });
            }

            return selectList;
        }


    }
}
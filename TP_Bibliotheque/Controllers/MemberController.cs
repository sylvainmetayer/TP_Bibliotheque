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
        public ActionResult Index()
        {
            var dal = new MemberDAL((List<Member>)Session["Members"]);
            var model = new MembersModelView(dal.GetAll());
            return View(model);
        }

        public ActionResult Details(int id)
        {
            AuthorDAL authorDAL = new AuthorDAL((List<Author>)Session["Authors"]);
            BookDAL bookDAL = new BookDAL((List<Book>)Session["Books"]);
            MemberDAL memberDAL = new MemberDAL((List<Member>)Session["Members"]);

            Member member = memberDAL.Read(id);
            ShowMemberModelView model = new ShowMemberModelView(member);
            return View(model);
        }
    }
}
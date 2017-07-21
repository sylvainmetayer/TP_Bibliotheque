﻿using System;
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

            ReservationDAL resaDAL = new ReservationDAL((List<BooksBorrowing>)Session["BooksBorrowing"]);

            Member member = memberDAL.Read(id);
            ShowMemberModelView model = new ShowMemberModelView(member);
            model.Reservations = resaDAL.GetByMember(member);

            return View(model);
        }

        public ActionResult Add()
        {
            Member member = new Member();

            return View(member);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name, Firstname, BirthDate, Email")]Member member)
        {
            MemberDAL dal = new MemberDAL((List<Member>)Session["Members"]);
            if (ModelState.IsValid)
            {
                dal.Add(member);
                return RedirectToAction("Index");
            }

            return RedirectToAction("Add");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TP_Bibliotheque.Models.DAL;
using TP_Bibliotheque.Models.Data;
using Random = TP_Bibliotheque.Models.Random.Random;

namespace TP_Bibliotheque
{

    // DOC : https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Session_Start()
        {
            BaseUser.IdMax = 0;

            // Init Authors
            GenerateAuthors();

            var dal = new AuthorDAL((List<Author>)Session["Authors"]);
            dal.Delete(2);
            dal.Update(3, new Author() { Id = 3, Firstname = "FirstName", Name = "Name" });

            GenerateBooks();
            GenerateMembers();

        }

        private void GenerateBooks()
        {

            var random = new Random();
            List<Author> authors = (List<Author>)Session["Authors"];
            Session["Books"] = new List<Book>();

            int nbAuthors = authors.Count;
            DateTime startDate = new DateTime(1800, 01, 01);
            DateTime endDate = new DateTime(2017, 06, 09);

            var dal = new BookDAL((List<Book>)Session["Books"]);

            for (int i = 0; i < random.Next(10, 20); i++)
            {
                String bookTitle = random.NextLoremIpsum(2);
                DateTime date = random.NextDate(startDate, endDate);
                String edition = random.NextString(8);
                int quantity = random.Next(10);
                String thematic = random.NextString(8);
                var selectedIndexAuthor = random.Next(0, nbAuthors - 1);
                Author selectedAuthor = authors.ElementAt(selectedIndexAuthor);

                Book book = new Book() { Author = selectedAuthor, AvailableQuantity = quantity, Edition = edition, PublicationDate = date, Thematic = thematic, Title = bookTitle };
                dal.Add(book);
            }
        }

        private void GenerateAuthors()
        {
            var random = new Random();

            Session["Authors"] = new List<Author>();

            var dal = new AuthorDAL((List<Author>)Session["Authors"]);

            for (int i = 0; i < random.Next(10, 20); i++)
            {
                Random.Person p = random.NextPerson(Random.AllowedLanguage.FRENCH);
                Author a = new Author() { Firstname = p.FirstName, Name = p.LastName };
                dal.Add(a);
            }
        }

        private void GenerateMembers()
        {
            var random = new Random();

            Session["Members"] = new List<Member>();

            DateTime startDate = new DateTime(1800, 01, 01);
            DateTime endDate = new DateTime(2017, 06, 09);

            var dal = new MemberDAL((List<Member>)Session["Members"]);

            for (int i = 0; i < random.Next(10, 20); i++)
            {
                String firstEmail = random.NextString(8);
                String secondEmail = random.NextString(8);
                String email = firstEmail + "@" + secondEmail + ".com";
                DateTime date = random.NextDate(startDate, endDate);
                Random.Person p = random.NextPerson(Random.AllowedLanguage.FRENCH);
                Member m = new Member() { Name = p.LastName, Firstname = p.FirstName, Email = email, BirthDate = date };
                dal.Add(m);
            }
        }
    }
}

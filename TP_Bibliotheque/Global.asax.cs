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
            List<Author> authors = new List<Author>();
            Author author = new Author() { Id = BaseUser.IdMax, Firstname = "FirstName", Name = "Name" };

            BaseUser.IdMax++;
            authors.Add(author);
            Session["Authors"] = authors;
        }

        /*
        private void GenerateAuteurs()
        {
            var random = new Random();

            var dal = new AuthorDAL();

            // on fabrique 100 livres au max
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                Random.Person p = random.NextPerson(Random.AllowedLanguage.FRENCH);
                Author a = new Author() { Id = BaseUser.IdMax, Firstname = p.FirstName, Name = p.LastName };
                dal.Add(a);
            }
        }*/
    }
}

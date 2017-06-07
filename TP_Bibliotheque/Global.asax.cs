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

        }


        private void GenerateAuthors()
        {
            var random = new Random();

            Session["Authors"] = new List<Author>();

            var dal = new AuthorDAL((List<Author>)Session["Authors"]);

            // on fabrique 100 auteurs au max
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                Random.Person p = random.NextPerson(Random.AllowedLanguage.FRENCH);
                Author a = new Author() { Firstname = p.FirstName, Name = p.LastName };
                dal.Add(a);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TP_Bibliotheque.Models.Data;

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
    }
}

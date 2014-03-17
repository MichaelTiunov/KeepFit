using System;
using System.IO;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Xml.Serialization;
using KeepFit.Web.Models;

namespace KeepFit.Web
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            SetDependencyResolver();
        }
        private static void SetDependencyResolver()
        {
            DependencyResolver.SetResolver(CompositionRoot.GetDependencyResolver());
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs args)
        {
            if (Context.User != null)
            {
                IPrincipal principal;

                var formsIdentity = Context.User.Identity as FormsIdentity;

                if (formsIdentity != null && (Context.User.Identity.IsAuthenticated
                                                                                   && (!string.IsNullOrEmpty(formsIdentity.Ticket.UserData))))
                {
                    using (var reader = new StringReader(formsIdentity.Ticket.UserData))
                    {
                        var serializer = new XmlSerializer(typeof(KeepFitPrincipal));
                        principal = (KeepFitPrincipal)serializer.Deserialize(reader);
                    }
                }
                else
                {
                    principal = new KeepFitPrincipal();
                }

                Context.User = principal;
            }
        }
    }
}

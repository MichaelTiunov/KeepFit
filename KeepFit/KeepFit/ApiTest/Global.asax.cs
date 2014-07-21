using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Identity;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;

namespace ApiTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Create the container as usual.
            var container = new Container();

            // Register your types, for instance using the RegisterWebApiRequest
            // extension from the integration package:
            container.RegisterWebApiRequest<IKeepFitContext>(() => new KeepFitContext());
            container.RegisterWebApiRequest<IAccountService, AccountService>();
            container.RegisterWebApiRequest<ISecurityService, SecurityService>();
            container.RegisterWebApiRequest<IIdentityService, IdentityService>();
            container.RegisterWebApiRequest<IBodyCompositionService, BodyCompositionService>();
            container.RegisterWebApiRequest<IProgressPhotoService, ProgressPhotoService>();
            container.RegisterWebApiRequest<IExcerciseService, ExcerciseService>();
            container.RegisterWebApiRequest<IWorkoutService, WorkoutService>();
            container.RegisterWebApiRequest<IProductService, ProductService>();
            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}

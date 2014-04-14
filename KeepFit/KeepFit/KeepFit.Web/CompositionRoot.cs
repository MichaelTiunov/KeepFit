using System.Reflection;
using System.Web.Mvc;
using KeepFit.Core.Models;
using KeepFit.Core.Services;
using KeepFit.Web.Models;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;

namespace KeepFit.Web
{
    public static class CompositionRoot
    {
        public static IDependencyResolver GetDependencyResolver()
        {
            return new SimpleInjectorDependencyResolver(ConstructContainer());
        }

        public static Container ConstructContainer(bool verify = false)
        {
            var container = new Container();

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcAttributeFilterProvider();


            //container.Register<IKeepFitContext>(() => new KeepFitContext(container.GetInstance<IIdentityAuditProvider>()));
            //container.Register<IDaikinContext, DaikinContext>();
            //TODO: REMOVEME
            container.Register<IKeepFitContext>(() => new KeepFitContext());
            container.Register<IAccountService, AccountService>();
            container.Register<ISecurityService, SecurityService>();
            container.Register<IIdentityService, IdentityService>();
            container.Register<IBodyCompositionService, BodyCompositionService>();
            container.Register<IProgressPhotoService, ProgressPhotoService>();

            //Verifies everything is registered correclty
            //TODO: Investigate possible effect (constructor calls?)
            if (verify)
            {
                container.Verify();
            }

            return container;
        }
    }
}
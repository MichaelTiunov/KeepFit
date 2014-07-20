using System;
using System.Web.Mvc;
using SimpleInjector;

namespace WebApiAuth.Filters
{
    public static class SimpleInjectorExtensionsForMvcFilters
    {
        private static SimpleInjectorMvcFilterCollection filters;

        public static void RegisterGlobalMvcFilter(this Container container, Type concreteType, Lifestyle lifestyle = null, int? filterOrder = null)
        {
            if (filters == null)
            {
                filters = new SimpleInjectorMvcFilterCollection(container);
                FilterProviders.Providers.Add(filters);
            }
            filters.AddFilter(concreteType, lifestyle, filterOrder);
        }
    }
}
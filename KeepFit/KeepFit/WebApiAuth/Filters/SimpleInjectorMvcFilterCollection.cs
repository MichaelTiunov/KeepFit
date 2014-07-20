using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using SimpleInjector;

namespace WebApiAuth.Filters
{
    internal class SimpleInjectorMvcFilterCollection : IFilterProvider, IEnumerable<Filter>
    {
        private class FilterTypeAndOrder
        {
            public Type Type { get; private set; }
            public int? Order { get; private set; }

            public FilterTypeAndOrder(Type type, int? order)
            {
                Type = type;
                Order = order;
            }
        }

        private readonly Container container;
        private readonly List<FilterTypeAndOrder> filterTypes = new List<FilterTypeAndOrder>();

        public SimpleInjectorMvcFilterCollection(Container container)
        {
            this.container = container;
        }

        public int Count
        {
            get { return filterTypes.Count; }
        }

        private IEnumerable<Filter> Filters
        {
            get
            {
                return
                    this.filterTypes.Select(
                        ft => new Filter(DependencyResolver.Current.GetService(ft.Type), FilterScope.Global, ft.Order));
            }
        }

        public void AddFilter<T>(Lifestyle lifestyle = null, int? order = null) where T : class
        {
            AddFilter(typeof(T), lifestyle, order);
        }

        public void AddFilter(Type t, Lifestyle lifestyle = null, int? order = null)
        {
            ValidateFilterType(t);
            container.Register(t, t, lifestyle ?? Lifestyle.Transient);
            filterTypes.Add(new FilterTypeAndOrder(t, order));
        }

        public void Clear()
        {
            filterTypes.Clear();
        }

        public bool Contains<T>()
        {
            return Contains(typeof(T));
        }

        public bool Contains(Type t)
        {
            return filterTypes.Any(f => f.Type == t);
        }

        public void Remove<T>()
        {
            Remove(typeof(T));
        }

        public void Remove(Type t)
        {
            filterTypes.RemoveAll(f => f.Type == t);
        }

        public IEnumerator<Filter> GetEnumerator()
        {
            return Filters.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Filters.GetEnumerator();
        }

        IEnumerable<Filter> IFilterProvider.GetFilters(ControllerContext controllerContext,
            ActionDescriptor actionDescriptor)
        {
            return this;
        }

        private static void ValidateFilterType(Type t)
        {
            if (!(
                typeof(IActionFilter).IsAssignableFrom(t) ||
                typeof(IAuthorizationFilter).IsAssignableFrom(t) ||
                typeof(IExceptionFilter).IsAssignableFrom(t) ||
                typeof(IResultFilter).IsAssignableFrom(t) ||
                typeof(IAuthenticationFilter).IsAssignableFrom(t)))
            {
                throw new InvalidOperationException(
                    "The given filter instance must implement one or more of the following filter interfaces: IAuthorizationFilter, IActionFilter, IResultFilter, IExceptionFilter.");
            }
        }
    }
}
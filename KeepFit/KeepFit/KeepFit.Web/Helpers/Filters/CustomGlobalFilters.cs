using System;
using System.Collections.Generic;

namespace KeepFit.Web.Helpers.Filters
{
    public static class CustomGlobalFilters
    {
        public static readonly Dictionary<Type, int?> FiltersWithOrders = new Dictionary<Type, int?>
        {
            //these filters can be executed in any order... let's put 1000, so they run last
            {typeof (CurrentUserToViewBagResultFilter), 1000},
        };

    }
}
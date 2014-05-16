using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using KeepFit.Web.Resources;

namespace KeepFit.Web.Helpers
{
    public static class EnumLocalizationHelper
    {
        public static IDictionary<TEnum, string> GetLocalizedNames<TEnum>()
        {
            return GetLocalizedNames<TEnum>(typeof(Enums));
        }

        public static IDictionary<TEnum, string> GetLocalizedNames<TEnum>(Type resourceType)
        {
            var enumDictionary = new Dictionary<TEnum, string>();

            IEnumerable<TEnum> values = Enum.GetValues(typeof(TEnum)).Cast<TEnum>();

            foreach (var value in values)
            {
                string localizedString = GetLocalizedName<TEnum>(value, resourceType);
                enumDictionary.Add(value, localizedString);
            }

            return enumDictionary;
        }

        public static string GetLocalizedName<TEnum>(TEnum value)
        {
            return GetLocalizedName<TEnum>(value, typeof(Enums));
        }

        public static string GetLocalizedName<TEnum>(TEnum value, Type resourceType)
        {
            var type = GetUnderlyingType<TEnum>();

            if (!type.IsEnum)
            {
                throw new NotSupportedException("Specfied value is not an enum value");
            }

            string localizedName = null;

            if (resourceType != null)
            {
                string resourceKey = string.Format("{0}.{1}", type.Name, value.ToString());

                PropertyInfo property = resourceType.GetProperties()
                    .FirstOrDefault(p => p.PropertyType == typeof(System.Resources.ResourceManager));

                if (property != null)
                {
                    localizedName = ((ResourceManager)property.GetValue(null, null)).GetString(resourceKey);
                }
            }

            if (localizedName == null && value != null)
            {
                localizedName = Enum.GetName(type, value);
            }

            return localizedName;
        }

        private static Type GetUnderlyingType<TEnum>()
        {
            Type type = typeof(TEnum);

            // checking if enum is not nullable:
            Type underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null) // if nullable, 
                return underlyingType; // then return underlying type

            return type;
        }
    }
}
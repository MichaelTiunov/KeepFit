using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace KeepFit.Core.Utils
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string s)
        {
            return string.IsNullOrWhiteSpace(s);
        }

        public static void ValidateNullOrEmpty(this string s)
        {
            if (s.IsNullOrEmpty())
                throw new InvalidOperationException();
        }

        public static void ValidateNullOrEmptyParam(this string s, string paramName)
        {
            if (s.IsNullOrEmpty())
                throw new ArgumentNullException(paramName);
        }

        public static string F(this string format, params object[] args)
        {
            return string.Format(format, args);
        }

        public static string ReplacePropertyPlaceholder(this string baseString, PropertyInfo property, object obj)
        {
            return baseString.Replace("<{0}>".F(property.Name),
                (string)property.GetValue(obj, null));
        }

        public static string ReplaceIgnoreCase(this string s, string what, string with)
        {
            return Regex.Replace(s, what, with, RegexOptions.IgnoreCase);
        }

        public static bool StartsWithIgnoreCase(this string s, string with)
        {
            return s.StartsWith(with, StringComparison.OrdinalIgnoreCase);
        }

        public static bool EqualsIgnoreCase(this string s, string to)
        {
            return s.Equals(to, StringComparison.OrdinalIgnoreCase);
        }
    }
}

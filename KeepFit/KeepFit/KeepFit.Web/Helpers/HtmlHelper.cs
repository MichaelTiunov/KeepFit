using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace KeepFit.Web.Helpers
{
    public static class EnumDropDownListHelper
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression, string optionalText, object htmlAttributes)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);

            var enumType = Nullable.GetUnderlyingType(metadata.ModelType) ?? metadata.ModelType;

            var enumValues = Enum.GetValues(enumType).Cast<TEnum>();

            var items = from enumValue in enumValues
                        select new SelectListItem
                        {
                            Text = EnumLocalizationHelper.GetLocalizedName(enumValue),
                            Value = enumValue.ToString(),
                            Selected = enumValue.Equals(metadata.Model)
                        };

            if (optionalText == null)
            {
                return html.DropDownListFor(expression, items, htmlAttributes);
            }

            return html.DropDownListFor(expression, items, optionalText, htmlAttributes);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TEnum>(this HtmlHelper<TModel> html, Expression<Func<TModel, TEnum>> expression, object htmlAttributes)
        {
            return EnumDropDownListFor(html, expression, null, htmlAttributes);
        }

    }
}
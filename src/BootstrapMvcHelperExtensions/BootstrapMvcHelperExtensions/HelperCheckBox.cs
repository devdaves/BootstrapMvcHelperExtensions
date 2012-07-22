namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using System.Web.Mvc.Html;
    using BootstrapMvcHelperExtensions.Extensions;

    /// <summary>
    /// All html helper checkbox input extension methods
    /// </summary>
    public static class HelperCheckBox
    {
        /// <summary>
        /// Bootstraps the check box for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapCheckBoxFor<TModel>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, bool>> expression, bool disabled = false)
        {
            TagBuilder container = Common.GetRootContainer();
            TagBuilder icontainer = Common.GetInputContainer();
            List<string> css = new List<string>();
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("class", Common.GetCss(css));

            ////MvcHtmlString label = htmlHelper.LabelFor(expression);
            MvcHtmlString label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);
            MvcHtmlString input = htmlHelper.CheckBoxFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString();
            container.InnerHtml = label.ToString() + icontainer.ToString();

            return container.ToMvcHtmlString();
        }
    }
}

﻿namespace BootstrapMvcHelperExtensions
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
    /// All html helper text area input extension methods
    /// </summary>
    public static class HelperTextArea
    {
        /// <summary>
        /// Bootstraps the text area for.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="rows">The rows.</param>
        /// <param name="inputSize">Size of the input.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <param name="helptext">The helptext.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, int rows = 2, InputSize inputSize = InputSize.medium, bool disabled = false, string helptext = "")
        {
            TagBuilder container = Common.GetRootContainer();
            TagBuilder icontainer = Common.GetInputContainer();
            List<string> css = new List<string>();
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            bool error = Common.HasValidationError(htmlHelper, ExpressionHelper.GetExpressionText(expression));

            if (error)
            {
                container.AddCssClass("error");
            }

            css.Add(Common.GetCssClass(inputSize));

            if (disabled)
            {
                css.Add("disabled");
                htmlAttributes.Add("disabled", "disabled");
            }

            htmlAttributes.Add("rows", rows);
            htmlAttributes.Add("class", Common.GetCss(css));

            ////MvcHtmlString label = htmlHelper.LabelFor(expression);
            MvcHtmlString label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);
            MvcHtmlString input = htmlHelper.TextAreaFor(expression, htmlAttributes);

            icontainer.InnerHtml = input.ToString() + Common.GetValidationMessageSpan(htmlHelper, ExpressionHelper.GetExpressionText(expression)) + Common.GetHelpSpan(helptext);
            container.InnerHtml = label.ToString() + icontainer.ToString();

            return container.ToMvcHtmlString();
        }
    }
}

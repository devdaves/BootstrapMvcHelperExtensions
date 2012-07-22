namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using BootstrapMvcHelperExtensions.Extensions;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public static class HelperUneditable
    {
        /// <summary>
        /// Bootstraps the uneditable input.
        /// </summary>
        /// <typeparam name="TModel">The type of the model.</typeparam>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="inputSize">Size of the input.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapUneditableInput<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, InputSize inputSize = InputSize.medium)
        {
            TagBuilder container = Common.GetRootContainer();
            TagBuilder icontainer = Common.GetInputContainer();
            TagBuilder disabledInput = new TagBuilder("span");

            List<string> css = new List<string>();
            Dictionary<string, object> htmlAttributes = new Dictionary<string, object>();
            ModelMetadata metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            disabledInput.AddCssClass(Common.GetCssClass(inputSize));
            disabledInput.AddCssClass("uneditable-input");
            disabledInput.InnerHtml = metadata.Model.ToString();
            MvcHtmlString label = Common.GetLabel(metadata.PropertyName, metadata.DisplayName);

            icontainer.InnerHtml = disabledInput.ToString();
            container.InnerHtml = label.ToString() + icontainer.ToString();

            return container.ToMvcHtmlString();
        }
    }
}

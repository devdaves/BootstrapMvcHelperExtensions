namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using BootstrapMvcHelperExtensions.Extensions;

    /// <summary>
    /// Common items used by more then one helper class
    /// </summary>
    internal static class Common
    {
        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="buttonType">Type of the button.</param>
        /// <returns>The css class of the button type</returns>
        internal static string GetCssClass(ButtonType buttonType)
        {
            switch (buttonType)
            {
                case ButtonType.@default:
                    return string.Empty;
                case ButtonType.primary:
                    return "btn-primary";
                case ButtonType.info:
                    return "btn-info";
                case ButtonType.success:
                    return "btn-success";
                case ButtonType.warning:
                    return "btn-warning";
                case ButtonType.danger:
                    return "btn-danger";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="buttonSize">Size of the button.</param>
        /// <returns>The css class of the button size</returns>
        internal static string GetCssClass(ButtonSize buttonSize)
        {
            switch (buttonSize)
            {
                case ButtonSize.@default:
                    return string.Empty;
                case ButtonSize.large:
                    return "btn-large";
                case ButtonSize.small:
                    return "btn-small";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="inputSize">Size of the input.</param>
        /// <returns>The css class of the input size</returns>
        internal static string GetCssClass(InputSize inputSize)
        {
            switch (inputSize)
            {
                case InputSize.small:
                    return "span2";
                case InputSize.medium:
                    return "span3";
                case InputSize.large:
                    return "span4";
                default:
                    return string.Empty;
            }
        }

        /// <summary>
        /// Gets the CSS.
        /// </summary>
        /// <param name="css">The CSS.</param>
        /// <returns>Comma delimited list of css classes</returns>
        internal static string GetCss(List<string> css)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var c in css)
            {
                sb.Append(string.Format("{0} ", c));
            }

            return sb.ToString();
        }

        /// <summary>
        /// Determines whether [has validation error] [the specified HTML helper].
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="name">The name.</param>
        /// <returns>
        ///   <c>true</c> if [has validation error] [the specified HTML helper]; otherwise, <c>false</c>.
        /// </returns>
        internal static bool HasValidationError(HtmlHelper htmlHelper, string name)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Gets the root container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        internal static TagBuilder GetRootContainer()
        {
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("control-group");
            return container;
        }

        /// <summary>
        /// Gets the input container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        internal static TagBuilder GetInputContainer()
        {
            TagBuilder container = new TagBuilder("div");
            container.AddCssClass("controls");
            return container;
        }

        /// <summary>
        /// Gets the label.
        /// </summary>
        /// <param name="labelFor">The label for.</param>
        /// <param name="value">The value.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetLabel(string labelFor, string value)
        {
            TagBuilder l = new TagBuilder("label");
            l.AddCssClass("control-label");
            l.Attributes.Add("for", labelFor);
            l.InnerHtml = value;

            return l.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the validation message span.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="expression">The expression.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetValidationMessageSpan(HtmlHelper htmlHelper, string expression)
        {
            string modelName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(expression);

            if (!htmlHelper.ViewData.ModelState.ContainsKey(modelName))
            {
                return new MvcHtmlString(string.Empty);
            }

            ModelState modelState = htmlHelper.ViewData.ModelState[modelName];
            ModelErrorCollection modelErrors = (modelState == null) ? null : modelState.Errors;
            ModelError modelError = ((modelErrors == null) || (modelErrors.Count == 0)) ? null : modelErrors.FirstOrDefault(m => !string.IsNullOrEmpty(m.ErrorMessage)) ?? modelErrors[0];

            if (modelError == null)
            {
                return new MvcHtmlString(string.Empty);
            }

            TagBuilder vtag = new TagBuilder("span");
            vtag.AddCssClass("help-inline");
            vtag.InnerHtml = modelError.ErrorMessage;

            return vtag.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the help span.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString GetHelpSpan(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                return new MvcHtmlString(string.Empty);
            }

            TagBuilder s = new TagBuilder("p");
            s.AddCssClass("help-block");
            s.InnerHtml = message;
            return s.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the button container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        internal static TagBuilder GetButtonContainer()
        {
            TagBuilder b = new TagBuilder("div");
            b.AddCssClass("form-actions");
            return b;
        }
    }
}

namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using BootstrapMvcHelperExtensions.Extensions;

    /// <summary>
    /// All html helper button input extension methods
    /// </summary>
    public static class HelperButton
    {
        /// <summary>
        /// A container for the form buttons
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>returns a BootstrapButtonContainer</returns>
        public static BootstrapButtonContainer BootstrapFormButtonContainer(this HtmlHelper htmlHelper)
        {
            htmlHelper.ViewContext.Writer.Write(Common.GetButtonContainer().ToString(TagRenderMode.StartTag));
            BootstrapButtonContainer buttonContainer = new BootstrapButtonContainer(htmlHelper.ViewContext);
            return buttonContainer;
        }

        /// <summary>
        /// Bootstraps the button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string id, string text, ButtonType buttonType = ButtonType.@default, ButtonSize buttonSize = ButtonSize.@default, bool disabled = false)
        {
            TagBuilder b = new TagBuilder("button");
            var typeCss = Common.GetCssClass(buttonType);
            var sizeCss = Common.GetCssClass(buttonSize);

            if (!string.IsNullOrEmpty(typeCss))
            {
                b.AddCssClass(typeCss);
            }

            if (!string.IsNullOrEmpty(sizeCss))
            {
                b.AddCssClass(sizeCss);    
            }
            
            b.AddCssClass("btn");

            if (disabled)
            {
                b.Attributes.Add("disabled", "disabled");
                b.AddCssClass("disabled");
            }

            b.Attributes.Add("id", id);
            b.InnerHtml = text;

            return b.ToMvcHtmlString();
        }

        /// <summary>
        /// Bootstraps the link button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="navigateTo">The navigate to.</param>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapLinkButton(this HtmlHelper htmlHelper, string id, string text, string navigateTo, ButtonType buttonType = ButtonType.@default, ButtonSize buttonSize = ButtonSize.@default)
        {
            TagBuilder a = new TagBuilder("a");
            var typeCss = Common.GetCssClass(buttonType);
            var sizeCss = Common.GetCssClass(buttonSize);

            if (!string.IsNullOrEmpty(typeCss))
            {
                a.AddCssClass(typeCss);
            }

            if (!string.IsNullOrEmpty(sizeCss))
            {
                a.AddCssClass(sizeCss);
            }

            a.AddCssClass("btn");

            if (!string.IsNullOrEmpty(id))
            {
                a.Attributes.Add("id", id);
            }

            if (!string.IsNullOrEmpty(navigateTo))
            {
                a.Attributes.Add("href", navigateTo);
            }
            
            a.InnerHtml = text;
            return a.ToMvcHtmlString();
        }
    }
}

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
        /// Start of the bootstrap button container
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapButtonsBegin(this HtmlHelper htmlHelper)
        {
            return GetButtonContainer().ToString(TagRenderMode.StartTag).ToMvcHtmlString();
            ////return string.Format("{0}{1}", GetRootContainer().ToString(TagRenderMode.StartTag), GetInputContainer().ToString(TagRenderMode.StartTag)).ToMvcHtmlString();
        }

        /// <summary>
        /// End of the bootstap button container
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <returns>An MvcHtmlString</returns>
        public static MvcHtmlString BootstrapButtonsEnd(this HtmlHelper htmlHelper)
        {
            return GetButtonContainer().ToString(TagRenderMode.EndTag).ToMvcHtmlString();
            ////return string.Format("{0}{1}", GetInputContainer().ToString(TagRenderMode.StartTag), GetRootContainer().ToString(TagRenderMode.StartTag)).ToMvcHtmlString();
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
            b.AddCssClass(Common.GetCssClass(buttonType));
            b.AddCssClass(Common.GetCssClass(buttonSize));
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
            a.AddCssClass(Common.GetCssClass(buttonType));
            a.AddCssClass(Common.GetCssClass(buttonSize));
            a.AddCssClass("btn");

            a.Attributes.Add("id", id);
            a.Attributes.Add("href", navigateTo);
            a.InnerHtml = text;

            return a.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the button container.
        /// </summary>
        /// <returns>A TagBuilder</returns>
        private static TagBuilder GetButtonContainer()
        {
            TagBuilder b = new TagBuilder("div");
            b.AddCssClass("form-actions");
            return b;
        }
    }
}

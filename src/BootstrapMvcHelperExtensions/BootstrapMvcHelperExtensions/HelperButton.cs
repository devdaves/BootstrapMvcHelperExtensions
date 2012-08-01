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
        /// <param name="icon">The icon.</param>
        /// <param name="inverted">if set to <c>true</c> [icon is inverted].</param>
        /// <param name="isSubmit">if set to <c>true</c> [is submit].</param>
        /// <returns>
        /// An MvcHtmlString
        /// </returns>
        public static MvcHtmlString BootstrapButton(this HtmlHelper htmlHelper, string id, string text, ButtonType buttonType = ButtonType.@default, ButtonSize buttonSize = ButtonSize.@default, bool disabled = false, Icon icon = Icon.@default, bool inverted = false, bool isSubmit = false)
        {
            var tag = new TagBuilder("button");
            if (isSubmit)
            {
                tag.Attributes.Add("type", "submit");
            }

            return ButtonBuilder(htmlHelper, id, text, string.Empty, tag, buttonType, buttonSize, disabled, icon, inverted);
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
        /// <param name="icon">The icon.</param>
        /// <param name="inverted">if set to <c>true</c> [icon is inverted].</param>
        /// <returns>
        /// An MvcHtmlString
        /// </returns>
        public static MvcHtmlString BootstrapLinkButton(this HtmlHelper htmlHelper, string id, string text, string navigateTo, ButtonType buttonType = ButtonType.@default, ButtonSize buttonSize = ButtonSize.@default, Icon icon = Icon.@default, bool inverted = false)
        {
            return ButtonBuilder(htmlHelper, id, text, navigateTo, new TagBuilder("a"), buttonType, buttonSize, false, icon, inverted);
        }

        /// <summary>
        /// Bootstraps the link button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <returns>
        /// An MvcHtmlString
        /// </returns>
        public static MvcHtmlString BootstrapSubmitButton(this HtmlHelper htmlHelper, string id, string text, ButtonType buttonType = ButtonType.@default, ButtonSize buttonSize = ButtonSize.@default, bool disabled = false)
        {
            var tag = new TagBuilder("input");
            tag.Attributes.Add("type", "submit");
            tag.Attributes.Add("value", text);
            return ButtonBuilder(htmlHelper, id, string.Empty, string.Empty, tag, buttonType, buttonSize, disabled, Icon.@default, false);
        }

        /// <summary>
        /// Builds a button.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="id">The id.</param>
        /// <param name="text">The text.</param>
        /// <param name="navigateTo">The navigate to.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="buttonType">Type of the button.</param>
        /// <param name="buttonSize">Size of the button.</param>
        /// <param name="disabled">if set to <c>true</c> [disabled].</param>
        /// <param name="icon">The icon.</param>
        /// <param name="inverted">if set to <c>true</c> [icon is inverted].</param>
        /// <returns>
        /// returns the MvcHtmlString representing the button
        /// </returns>
        private static MvcHtmlString ButtonBuilder(HtmlHelper htmlHelper, string id, string text, string navigateTo, TagBuilder tag, ButtonType buttonType, ButtonSize buttonSize, bool disabled, Icon icon, bool inverted)
        {
            var typeCss = GetCssClass(buttonType);
            var sizeCss = GetCssClass(buttonSize);
            var iconHtml = HelperIcon.BootstrapIcon(htmlHelper, icon, inverted);
            
            if (!string.IsNullOrEmpty(typeCss))
            {
                tag.AddCssClass(typeCss);
            }

            if (!string.IsNullOrEmpty(sizeCss))
            {
                tag.AddCssClass(sizeCss);
            }

            tag.AddCssClass("btn");

            if (!string.IsNullOrEmpty(id))
            {
                tag.Attributes.Add("id", id);
            }

            if (!string.IsNullOrEmpty(navigateTo))
            {
                tag.Attributes.Add("href", navigateTo);
            }

            if (disabled)
            {
                tag.Attributes.Add("disabled", "disabled");
                tag.AddCssClass("disabled");
            }

            tag.InnerHtml = iconHtml + text;
            return tag.ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="buttonType">Type of the button.</param>
        /// <returns>The css class of the button type</returns>
        private static string GetCssClass(ButtonType buttonType)
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
        private static string GetCssClass(ButtonSize buttonSize)
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
    }
}

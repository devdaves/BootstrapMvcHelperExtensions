namespace BootstrapMvcHelperExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Mvc;
    using BootstrapMvcHelperExtensions.Extensions;

    /// <summary>
    /// All html helper icon extension methods
    /// </summary>
    public static class HelperIcon
    {
        /// <summary>
        /// Bootstraps the icon.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="icon">The icon.</param>
        /// <param name="inverted">if set to <c>true</c> [inverted].</param>
        /// <returns>returns MvcHtmlString of icon</returns>
        public static MvcHtmlString BootstrapIcon(this HtmlHelper htmlHelper, Icon icon, bool inverted = false)
        {
            if (icon == Icon.@default)
            {
                return string.Empty.ToMvcHtmlString();
            }

            TagBuilder t = new TagBuilder("i");
            t.AddCssClass(GetCssClass(icon));
            if (inverted)
            {
                t.AddCssClass("icon-white");
            }

            // add a space after the li tag incase it is next to text or used in a button
            return string.Format("{0} ", t.ToString()).ToMvcHtmlString();
        }

        /// <summary>
        /// Gets the CSS class.
        /// </summary>
        /// <param name="icon">The icon.</param>
        /// <returns>returns the class of the icon</returns>
        private static string GetCssClass(Icon icon)
        {
            return icon.ToString().Replace('_', '-');
        }
    }
}

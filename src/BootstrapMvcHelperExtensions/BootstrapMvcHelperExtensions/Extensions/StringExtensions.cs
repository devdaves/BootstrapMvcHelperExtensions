﻿namespace BootstrapMvcHelperExtensions.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    /// <summary>
    /// String Extension methods
    /// </summary>
    internal static class StringExtensions
    {
        /// <summary>
        /// Converts a string to an MVC HTML string
        /// </summary>
        /// <param name="stringValue">The string value.</param>
        /// <returns>An MvcHtmlString</returns>
        internal static MvcHtmlString ToMvcHtmlString(this string stringValue)
        {
            return new MvcHtmlString(stringValue);
        }
    }
}

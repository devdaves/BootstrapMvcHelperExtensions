namespace BootstrapMvcHelperExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HelperIconTests
    {
        [TestMethod]
        public void BootstrapIcon_DefaultIcon_returns_empty_string()
        {
            string expected = string.Empty;
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.@default).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapIcon_DefaultIcon_Is_Inverted_returns_empty_string()
        {
            string expected = string.Empty;
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.@default, true).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapIcon_Glass_Not_Inverted()
        {
            // <i class="icon-glass"></i> 
            string expected = "<i class=\"icon-glass\"></i> ";
            var htmlHelper = Util.GetHtmlHelper();
            
            var result = htmlHelper.BootstrapIcon(Icon.icon_glass).ToString();

            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void BootstrapIcon_Glass_Is_Inverted()
        {
            // <i class="icon-white icon-glass"></i> 
            string expected = "<i class=\"icon-white icon-glass\"></i> ";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapIcon(Icon.icon_glass, true).ToString();

            Assert.AreEqual(expected, result);
        }
    }
}

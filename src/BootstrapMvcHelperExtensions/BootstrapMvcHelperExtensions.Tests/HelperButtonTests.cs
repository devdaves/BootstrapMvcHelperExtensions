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
    public class HelperButtonTests
    {
        [TestMethod]
        public void BootstrapButton_Default()
        {
            // <button class="btn" id="id">text</button>
            string expected = "<button class=\"btn\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();
            
            var result = htmlHelper.BootstrapButton("id", "text").ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Primary()
        {
            // <button class="btn btn-primary" id="id">text</button>
            string expected = "<button class=\"btn btn-primary\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();
            
            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.primary).ToString();

            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Info()
        {
            // <button class="btn btn-info" id="id">text</button>
            string expected = "<button class=\"btn btn-info\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.info).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Success()
        {
            // <button class="btn btn-success" id="id">text</button>
            string expected = "<button class=\"btn btn-success\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.success).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Warning()
        {
            // <button class="btn btn-warning" id="id">text</button>
            string expected = "<button class=\"btn btn-warning\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.warning).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonType_Danger()
        {
            // <button class="btn btn-danger" id="id">text</button>
            string expected = "<button class=\"btn btn-danger\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.danger).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_ButtonSize_Large()
        {
            // <button class="btn btn-large" id="id">text</button>
            string expected = "<button class=\"btn btn-large\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.large).ToString();

            Assert.AreEqual(expected, result);            
        }

        [TestMethod]
        public void BootstrapButton_ButtonSize_Small()
        {
            // <button class="btn btn-large" id="id">text</button>
            string expected = "<button class=\"btn btn-small\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.small).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_Disable_True()
        {
            // <button class="disabled btn" disabled="disabled" id="id">text</button>
            string expected = "<button class=\"disabled btn\" disabled=\"disabled\" id=\"id\">text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.@default, true).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_IconGlass_Not_Inverted()
        {
            // <button class="btn" id="id"><i class="icon-glass"></i> text</button>
            string expected = "<button class=\"btn\" id=\"id\"><i class=\"icon-glass\"></i> text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.@default, false, Icon.icon_glass, false).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapButton_IconGlass_Is_Inverted()
        {
            // <button class="btn" id="id"><i class="icon-white icon-glass"></i> text</button>
            string expected = "<button class=\"btn\" id=\"id\"><i class=\"icon-white icon-glass\"></i> text</button>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapButton("id", "text", ButtonType.@default, ButtonSize.@default, false, Icon.icon_glass, true).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapFormButtonContainer()
        {
            // <div class="form-actions"></div>
            string expected = "<div class=\"form-actions\"></div>";
            StringBuilder output = new StringBuilder();
            var htmlHelper = Util.GetHtmlHelper(output);

            using (htmlHelper.BootstrapFormButtonContainer())
            {
            }

            Assert.AreEqual(expected, output.ToString());
        }

        [TestMethod]
        public void BootstrapLinkButton_Default()
        {
            // <a class="btn" href="#" id="id">text</a>
            string expected = "<a class=\"btn\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#").ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonType_Primary()
        {
            // <a class="btn btn-primary" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-primary\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.primary).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonType_Info()
        {
            // <a class="btn btn-info" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-info\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.info).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonType_Success()
        {
            // <a class="btn btn-success" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-success\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.success).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonType_Warning()
        {
            // <a class="btn btn-warning" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-warning\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.warning).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonType_Danger()
        {
            // <a class="btn btn-danger" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-danger\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.danger).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonSize_Large()
        {
            // <a class="btn btn-large" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-large\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.@default, ButtonSize.large).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapLinkButton_ButtonSize_small()
        {
            // <a class="btn btn-small" href="#" id="id">text</a>
            string expected = "<a class=\"btn btn-small\" href=\"#\" id=\"id\">text</a>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapLinkButton("id", "text", "#", ButtonType.@default, ButtonSize.small).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_Default()
        {
            // <input class="btn" id="id" type="submit">text</input>
            string expected = "<input class=\"btn\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text").ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonType_Primary()
        {
            // <input class="btn btn-primary" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-primary\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.primary).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonType_Info()
        {
            // <input class="btn btn-info" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-info\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.info).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonType_Success()
        {
            // <input class="btn btn-success" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-success\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.success).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonType_Warning()
        {
            // <input class="btn btn-warning" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-warning\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.warning).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonType_Danger()
        {
            // <input class="btn btn-danger" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-danger\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.danger).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonSize_Large()
        {
            // <input class="btn btn-large" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-large\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.@default, ButtonSize.large).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_ButtonSize_Small()
        {
            // <input class="btn btn-small" id="id" type="submit">text</input>
            string expected = "<input class=\"btn btn-small\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.@default, ButtonSize.small).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_Disable_True()
        {
            // <input class="disabled btn" disabled="disabled" id="id" type="submit">text</input>
            string expected = "<input class=\"disabled btn\" disabled=\"disabled\" id=\"id\" type=\"submit\">text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.@default, ButtonSize.@default, true).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_IconGlass_Not_Inverted()
        {
            // <input class="btn" id="id" type="submit"><i class="icon-glass"></i> text</input>
            string expected = "<input class=\"btn\" id=\"id\" type=\"submit\"><i class=\"icon-glass\"></i> text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.@default, ButtonSize.@default, false, Icon.icon_glass, false).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapSubmitButton_IconGlass_Is_Inverted()
        {
            // <input class="btn" id="id" type="submit"><i class="icon-white icon-glass"></i> text</input>
            string expected = "<input class=\"btn\" id=\"id\" type=\"submit\"><i class=\"icon-white icon-glass\"></i> text</input>";
            var htmlHelper = Util.GetHtmlHelper();

            var result = htmlHelper.BootstrapSubmitButton("id", "text", ButtonType.@default, ButtonSize.@default, false, Icon.icon_glass, true).ToString();

            Assert.AreEqual(expected, result);
        }
    }
}

namespace BootstrapMvcHelperExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Text;
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using BootstrapMvcHelperExtensions.Tests.TestModels;
    
    [TestClass]
    public class HelperTextBoxTests
    {
        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_No_Client_Validation()
        {
            // <div class="control-group">
            //    <label class="control-label" for="FirstName">First Name</label>
            //    <div class="controls">
            //       <input class="input-medium" id="FirstName" name="FirstName" type="text" value="Dave" />
            //    </div>
            // </div>
            var expected = "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Dave\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Dave" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_With_Client_Validation()
        {
            // <div class="control-group">
            //    <label class="control-label" for="FirstName">First Name</label>
            //    <div class="controls">
            //       <input class="input-medium" data-val="true" data-val-required="The First Name field is required." id="FirstName" name="FirstName" type="text" value="Dave" />
            //    </div>
            // </div>
            var expected = "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium\" data-val=\"true\" data-val-required=\"The First Name field is required.\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Dave\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Dave" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_InValid_No_Client_Validation()
        {
            // <div class="error control-group">
            //    <label class="control-label" for="FirstName">First Name</label>
            //    <div class="controls">
            //       <input class="input-validation-error input-medium" id="FirstName" name="FirstName" type="text" value="" />
            //       <span class="help-inline">The First Name field is required.</span>
            //    </div>
            // </div>
            var expected = "<div class=\"error control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-validation-error input-medium\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"\" /><span class=\"help-inline\">The First Name field is required.</span></div></div>";
            var model = new Contact() { Id = 1, FirstName = string.Empty };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_InValid_With_Client_Validation()
        {
            // <div class="error control-group">
            //   <label class="control-label" for="FirstName">First Name</label>
            //   <div class="controls">
            //      <input class="input-validation-error input-medium" data-val="true" data-val-required="The First Name field is required." id="FirstName" name="FirstName" type="text" value="" />
            //      <span class="help-inline">The First Name field is required.</span>
            //   </div>
            // </div>
            var expected = "<div class=\"error control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-validation-error input-medium\" data-val=\"true\" data-val-required=\"The First Name field is required.\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"\" /><span class=\"help-inline\">The First Name field is required.</span></div></div>";
            var model = new Contact() { Id = 1, FirstName = string.Empty };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, true, true);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName).ToString();

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void BootstrapTextBoxFor_Model_Valid_No_Client_Validation_Disabled()
        {
            // <div class="control-group">
            //    <label class="control-label" for="FirstName">First Name</label>
            //    <div class="controls">
            //       <input class="input-medium disabled" disabled="disabled" id="FirstName" name="FirstName" type="text" value="Test" />
            //    </div>
            // </div>
            var expected = "<div class=\"control-group\"><label class=\"control-label\" for=\"FirstName\">First Name</label><div class=\"controls\"><input class=\"input-medium disabled\" disabled=\"disabled\" id=\"FirstName\" name=\"FirstName\" type=\"text\" value=\"Test\" /></div></div>";
            var model = new Contact() { Id = 1, FirstName = "Test" };
            var htmlHelper = Util.GetHtmlHelper<Contact>(model, false, false);

            var result = htmlHelper.BootstrapTextBoxFor(x => x.FirstName, disabled: true).ToString();

            Assert.AreEqual(expected, result);
        }
    }
}

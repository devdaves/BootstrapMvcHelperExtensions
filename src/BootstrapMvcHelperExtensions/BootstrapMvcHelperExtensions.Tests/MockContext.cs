namespace BootstrapMvcHelperExtensions.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web;
    using System.Web.Mvc;
    using Moq;
    using System.Web.Routing;
    using System.IO;

    public class MockContext
    {
        public Mock<RequestContext> RoutingRequestContext { get; private set; }
        public Mock<HttpContextBase> Http { get; private set; }
        public Mock<HttpServerUtilityBase> Server { get; private set; }
        public Mock<HttpResponseBase> Response { get; private set; }
        public Mock<HttpRequestBase> Request { get; private set; }
        public Mock<HttpSessionStateBase> Session { get; private set; }
        public Mock<ActionExecutingContext> ActionExecuting { get; private set; }
        public Mock<IViewDataContainer> ViewData { get; private set; }
        public Mock<IViewEngine> ViewEngine { get; private set; }
        public Mock<ControllerBase> Controller { get; private set; }
        public Mock<ControllerContext> ControllerContext { get; private set; }
        public Mock<ViewContext> ViewContext { get; private set; }
        public Mock<FormContext> FormContext { get; private set; }

        public HttpCookieCollection Cookies { get; private set; }
        public ViewDataDictionary ViewDataDictionary { get; private set; }
        public RouteData RouteData { get; private set; }
        public StringBuilder WriterOutput { get; set; }

        public MockContext(string viewName = "ViewName", bool clientValidationEnabled = true)
        {
            this.RoutingRequestContext = new Mock<RequestContext>(MockBehavior.Loose);
            this.Http = new Mock<HttpContextBase>(MockBehavior.Loose);
            this.Server = new Mock<HttpServerUtilityBase>(MockBehavior.Loose);
            this.Response = new Mock<HttpResponseBase>(MockBehavior.Loose);
            this.Request = new Mock<HttpRequestBase>(MockBehavior.Loose);
            this.Session = new Mock<HttpSessionStateBase>(MockBehavior.Loose);
            this.ActionExecuting = new Mock<ActionExecutingContext>(MockBehavior.Loose);
            this.ViewData = new Mock<IViewDataContainer>();
            this.ViewEngine = new Mock<IViewEngine>();
            this.Controller = new Mock<ControllerBase>();
            this.ControllerContext = new Mock<ControllerContext>();
            this.ViewContext = new Mock<ViewContext>();
            this.FormContext = new Mock<FormContext>();
            
            this.Cookies = new HttpCookieCollection();
            this.ViewDataDictionary = new ViewDataDictionary();
            this.RouteData = new RouteData();
            this.WriterOutput = new StringBuilder();

            this.RoutingRequestContext.SetupGet(c => c.HttpContext).Returns(this.Http.Object);
            this.ActionExecuting.SetupGet(c => c.HttpContext).Returns(this.Http.Object);
            this.Http.SetupGet(c => c.Request).Returns(this.Request.Object);
            this.Http.SetupGet(c => c.Response).Returns(this.Response.Object);
            this.Http.SetupGet(c => c.Server).Returns(this.Server.Object);
            this.Http.SetupGet(c => c.Session).Returns(this.Session.Object);
            this.Request.Setup(c => c.Cookies).Returns(this.Cookies);
            this.ViewData.Setup(c => c.ViewData).Returns(this.ViewDataDictionary);

            this.ControllerContext.Setup(c => c.Controller).Returns(this.Controller.Object);
            this.ViewContext.Setup(c => c.Controller).Returns(this.ControllerContext.Object.Controller);
            this.ViewContext.Setup(c => c.View).Returns(new RazorView(this.ControllerContext.Object, viewName, "Layout", false, new string[] { }));
            this.ViewContext.Setup(c => c.ViewData).Returns(new ViewDataDictionary());
            this.ViewContext.Setup(c => c.TempData).Returns(new TempDataDictionary());
            this.ViewContext.Setup(c => c.Writer).Returns(new StringWriter(this.WriterOutput));
            this.ViewContext.Setup(c => c.RouteData).Returns(this.RouteData);
            this.ViewContext.Setup(c => c.HttpContext).Returns(this.Http.Object);
            this.ViewContext.Setup(c => c.ClientValidationEnabled).Returns(clientValidationEnabled);
            this.ViewContext.Setup(c => c.UnobtrusiveJavaScriptEnabled).Returns(clientValidationEnabled);
            this.ViewContext.Setup(c => c.FormContext).Returns(this.FormContext.Object);

        }


    }
}

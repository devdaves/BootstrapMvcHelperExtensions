using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestWeb.Models;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Icons()
        {
            return View();
        }

        public ActionResult Buttons()
        {
            return View();
        }

        public ActionResult TextBox()
        {
            var model = new Contact() { Id = 1 };
            return View(model);
        }

        [HttpPost]
        public ActionResult TextBox(Contact model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("TextBox");
            }
            return View(model);
        }

    }
}

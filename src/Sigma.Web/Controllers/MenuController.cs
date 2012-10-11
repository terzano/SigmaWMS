using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sigma.Web.Controllers
{
    public class MenuController : Controller
    {
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult In()
        {
            return View();
        }

        public ActionResult Out()
        {
            return View();
        }

    }
}

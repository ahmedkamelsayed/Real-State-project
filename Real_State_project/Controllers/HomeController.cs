using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State_project.Controllers
{
    public class HomeController : Controller
    {
        // /Home/index
        public ActionResult Index()
        {
            return View();
        }

        // /Home/HomeProfile
        // GET: Home
        public ActionResult HomeProfile()
        {
            return View();
        }
    }
}
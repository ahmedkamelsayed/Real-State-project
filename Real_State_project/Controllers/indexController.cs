using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Real_State_project.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        // /index/index
        public ActionResult Index()
        {
            return View();
        }
    }
}
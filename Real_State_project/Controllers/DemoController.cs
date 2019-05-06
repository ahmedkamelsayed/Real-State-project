using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;
using Real_State_project.Models;

namespace Real_State_project.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "Customer")]
        public ActionResult work1()
        {
            return View("work1");
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult work2()
        {
            return View("work2");
        }

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult work3()
        {
            return View("work3");
        }

        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult work4()
        {
            return View("work4");
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult work5()
        {
            return View("work5");
        }
    }
}
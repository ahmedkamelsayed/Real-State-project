using Real_State_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class JuniorEngineersController : Controller
    {
        IAEntities1 db = new IAEntities1();
        // GET: JuniorEngineers

        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult listInformation()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult listproject()
        {
            var project = db.projects.ToList();
            ViewBag.projects = project;
            return View(project);
        }

        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult listprojectReq()
        {
            var requests = db.hiringRequest.ToList();
            return View(requests);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult EditRequest(int id)
        {
            var request = db.hiringRequest.SingleOrDefault(c => c.Id == id);
            return View(request);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "JuniorEngineer")]
        public ActionResult EditRequest(int Id, string statusid)
        {
            var req = db.hiringRequest.SingleOrDefault(c => c.Id == Id);
            req.statusid = int.Parse(statusid);
            db.SaveChanges();
            return RedirectToAction("listprojectReq");
        }
    }
}
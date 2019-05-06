using Real_State_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class TeamLeadersController : Controller
    {
        IAEntities1 db = new IAEntities1();
        // GET: TeamLeaders

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult AddFeedback()
        {

            feedback feedbacks = new feedback();
            
            return View(feedbacks);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult AddFeedback(feedback feedback)
        {
            db.feedback.Add(feedback);
            db.SaveChanges();
            return RedirectToAction("AddFeedback");

        }


        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult listJE()
        {
            var je = db.users.ToList();
            return View(je);
        }

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult delete(int id)
        {

            var user = db.users.SingleOrDefault(c => c.Id == id);
            var deluser = db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("listJE");
        }

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult listInformation()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult listproject()
        {
            var project = db.projects.ToList();
            ViewBag.projects = project;
            return View(project);
        }

        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult listprojectReq()
        {
            var requests = db.hiringRequest.ToList();
            return View(requests);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult EditRequest(int id)
        {
            var request = db.hiringRequest.SingleOrDefault(c => c.Id == id);
            return View(request);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "TeamLeader")]
        public ActionResult EditRequest(int Id, string statusid)
        {
            var req = db.hiringRequest.SingleOrDefault(c => c.Id == Id);
            req.statusid = int.Parse(statusid);
            db.SaveChanges();
            return RedirectToAction("listprojectReq");
        }
    }
}
using Real_State_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class ProjectManagersController : Controller
    {
        IAEntities1 db = new IAEntities1();
        // GET: ProjectManagers ان

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult listFeedbacks()
        {
            var feedbacks = db.feedback.ToList();
            return View(feedbacks);
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult listJE()
        {
            var je = db.users.ToList();
            return View(je);
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult Search(string searchBy , string search)
        {
            if (searchBy == "firstname")
            {
                return View(db.users.Where(x => x.firstname == search || search == null).ToList());
            }
            else
                return View(db.users.Where(x => x.lastname == search || search == null).ToList());
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult SearchTL(string searchBy, string search)
        {
            if (searchBy == "firstname")
            {
                return View(db.users.Where(x => x.firstname == search || search == null).ToList());
            }
            else
                return View(db.users.Where(x => x.lastname == search || search == null).ToList());
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult listProjects()
        {
            var project = db.projects.ToList();
            ViewBag.projects = project;
            return View(project);
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult manage(int id)
        {
            var pro = db.projects.SingleOrDefault(c => c.id == id);
            pro.progressstatus = 1;
            db.SaveChanges();
            return RedirectToAction("listProjects");
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult listPMProjects()
        {
            var project = db.projects.ToList();
            return View(project);
        }

        //[HttpGet]
        //[CustomAuthorize(Roles = "ProjectManager")]
        //public ActionResult Edit(int id)
        //{
        //    var user = db.projects.SingleOrDefault(c => c.id == id);
        //    return View(user);
        //}

        //[HttpPost]
        //[CustomAuthorize(Roles = "ProjectManager")]
        //public ActionResult Edit(int id, int price)
        //{
        //    var projectdetails = db.projectdetails.SingleOrDefault(c => c.Id == id);
        //    projectdetails.price = price;
        //    db.SaveChanges();
        //    return RedirectToAction("listPMProjects");
        //}

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult listInformation()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult CreatTeam(int id)
        {
            ViewBag.proid = id;
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "ProjectManager")]
        public ActionResult request(int user_id, int pro_id)
        {
            var request = new hiringRequest()
            {
                projectid = pro_id,
                userid = user_id,
                statusid = 6
            };
            db.hiringRequest.Add(request);
            db.SaveChanges();
            return RedirectToAction("CreatTeam/" + pro_id);
        }
    }
}
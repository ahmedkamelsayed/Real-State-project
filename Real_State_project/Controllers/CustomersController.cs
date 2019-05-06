using Real_State_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class CustomersController : Controller
    {
        IAEntities1 db = new IAEntities1();
        // GET: Customers

        // /Customer/CustomerProfile
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult CustomerProfile()
        {
            return View();
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult AddProject()
        {

            projects project = new projects();
            var projects = db.projects.ToList();
            ViewBag.projects = projects;
            //user = db.UserRole.Where(c => c.Id != 1).ToList();
            return View(project);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult AddProject(projects project)
        {
            db.projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("AddProject");
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult AddProjectCustomer ()
        {
            projects project = new projects();
            users user = new users();
            var projects = db.projects.ToList();
            var users = db.users.ToList();
            ViewBag.projects = projects;
            ViewBag.users = users;
            //user = db.UserRole.Where(c => c.Id != 1).ToList();
            return View(project);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult AddProjectCustomer(projects project)
        {
            db.projects.Add(project);
            db.SaveChanges();
            return RedirectToAction("AddProjectCustomer");
        }

        [CustomAuthorize(Roles = "Customer")]
        public ActionResult requestedProject()
        {
            var projects = db.projects.ToList();
            return View(projects);
        }

        [CustomAuthorize(Roles = "Customer")]
        public ActionResult listInformation()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult EditRequestedProjects(int id)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            return View(project);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult EditRequestedProjects(int id, string titel, string description, int progressstatus)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            project.description = description;
            project.titel = titel;
            project.progressstatus = progressstatus;
            db.SaveChanges();
            return RedirectToAction("requestedProject");
        }

        [CustomAuthorize(Roles = "Customer")]
        public ActionResult deleteProject(int id)
        {

            var project = db.projects.SingleOrDefault(c => c.id == id);
            var delproject = db.projects.Remove(project);
            db.SaveChanges();
            ViewBag.projects = project;
            return View(project);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult Editprojects(int id)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            return View(project);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Customer")]
        public ActionResult Editprojects(int id, string titel, string description)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            project.description = description;
            project.titel = titel;
            db.SaveChanges();
            return RedirectToAction("AddProject");
        }

    }
}
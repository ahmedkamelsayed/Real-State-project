using Real_State_project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class AdminController : Controller
    {
        // test mna4 da3wa beeh ////////////
        IAEntities1 db = new IAEntities1();
        // GET: Admin

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult list()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listCT()
        {
            var users = db.users.ToList();
            return View(users);
        }
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listPM()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listTL()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listJE()
        {
            var users = db.users.ToList();
            return View(users);
        }

        // /Admin/AddUser
        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult AddUser()
        {
           
            users user = new users();
            //user = db.UserRole.Where(c => c.Id != 1).ToList();
            return View(user);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult AddUser(users user)
        {
            db.users.Add(user);
            db.SaveChanges();
            return RedirectToAction("list");
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            var user =db.users.SingleOrDefault(c => c.Id == id);
            return View(user);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult Edit(int id ,string email ,string firstname ,string lastname ,string phone ,string jobDescription)
        {
            var user = db.users.SingleOrDefault(c => c.Id == id);
            user.lastname = lastname;
            user.firstname = firstname;
            user.email = email;
            user.phone = phone;
            user.jobDescription = jobDescription;
            db.SaveChanges();
            return RedirectToAction("list");
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult delete(int id)
        {

            var user = db.users.SingleOrDefault(c => c.Id== id);
            var deluser = db.users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("list");
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listProjects()
        {
            var projects = db.projects.ToList();
            return View(projects);
        }

        [HttpGet]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult EditProjects(int id)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            return View(project);
        }

        [HttpPost]
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult EditProjects(int id, string titel, string description, int statusid)
        {
            var project = db.projects.SingleOrDefault(c => c.id == id);
            project.description = description;
            project.titel = titel;
            project.statusid = statusid;
            db.SaveChanges();
            return RedirectToAction("listProjects");
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult listInformation ()
        {
            var users = db.users.ToList();
            return View(users);
        }

        [CustomAuthorize(Roles = "Admin")]
        public ActionResult deleteProject(int id)
        {

            var project = db.projects.SingleOrDefault(c => c.id == id);
            var delproject = db.projects.Remove(project);
            db.SaveChanges();
            return RedirectToAction("listProjects");
        }

        //../////////////////////////////

        // /Admin/AdminProfile
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult AdminProfile()
        {
            return View();
        }

        // /Admin/add
        [CustomAuthorize(Roles = "Admin")]
        public ActionResult add()
        {
            return View();
        }

    }
}
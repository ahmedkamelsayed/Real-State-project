using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Real_State_project.ViewModels;
using Real_State_project.Models;
using Real_State_project.Security;

namespace Real_State_project.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AccountViewModel avm)
        {
            AccountModel am = new AccountModel();
            if (string.IsNullOrEmpty(avm.Account.username) || string.IsNullOrEmpty(avm.Account.password) || am.login(avm.Account.username, avm.Account.password) == null)
            {
                ViewBag.Error = "Account's Invalid";
                return View("Index");
            }
            sessionPersiter.Username = avm.Account.username;
            return View("Success");
        }


        public ActionResult Logout(AccountViewModel avm)
        {
            sessionPersiter.Username = string.Empty;
            return RedirectToAction("Index");
        }

        public ActionResult register()
        {

            users user = new users();
            //user = db.UserRole.Where(c => c.Id != 1).ToList();

            return View(user);
        }

    }
}
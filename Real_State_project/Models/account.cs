using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace Real_State_project.Models
{
    public class account
    {
        [Display(Name = "Username ")]
        public string username { set; get; }

        [Display(Name = "Password ")]
        public string password { set; get; }

        public string[] roles { set; get; }
    }
}
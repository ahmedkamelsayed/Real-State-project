using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Real_State_project.Models;

namespace Real_State_project.Security
{
    public class CustomPrincpal : IPrincipal
    {
        private account account;


        public CustomPrincpal(account account)
        {
            this.account = account;
            this.Identity = new GenericIdentity(account.username);
        }

        public IIdentity Identity
        {
            get;
            set;
        }

        public bool IsInRole(string role)
        {
            var roles = role.Split(new char[] { ';' });
            return roles.Any(r => this.account.roles.Contains(r));
        }
    }
}